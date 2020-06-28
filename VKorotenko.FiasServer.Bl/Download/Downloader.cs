#region License

// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  02.06.2020 7:13

#endregion

using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;
using VKorotenko.FiasServer.Bl.Loggers;

namespace VKorotenko.FiasServer.Bl.Download
{
    public class Download
    {
        private string _filename;
        private readonly ILogger _logger;
        public bool Paused;
        private readonly SemaphoreSlim pauseLock = new SemaphoreSlim(1);

        public bool stop = true; // by default stop is true

        public Download(ILogger logger)
        {
            _logger = logger;
        }

        public event EventHandler<DownloadStatusChangedEventArgs> ResumablityChanged;
        public event EventHandler<DownloadProgressChangedEventArgs> ProgressChanged;
        public event EventHandler Completed;

        public void DownloadFile(string downloadLink, string path)
        {
            _filename = Path.GetFileName(path);

            stop = false; // always set this bool to false, everytime this method is called

            var fileInfo = new FileInfo(path);
            long existingLength = 0;
            if (fileInfo.Exists)
                existingLength = fileInfo.Length;

            var request = (HttpWebRequest) WebRequest.Create(downloadLink);
            request.Proxy = null;
            request.AddRange(existingLength);

            try
            {
                using (var response = (HttpWebResponse) request.GetResponse())
                {
                    var fileSize =
                        existingLength +
                        response
                            .ContentLength; //response.ContentLength gives me the size that is remaining to be downloaded
                    bool downloadResumable; // need it for not sending any progress

                    if ((int) response.StatusCode == 206
                    ) //same as: response.StatusCode == HttpStatusCode.PartialContent
                    {
                        _logger.LogMessage("Resumable");
                        downloadResumable = true;
                    }
                    else // sometimes a server that supports partial content will lose its ability to send partial content(weird behavior) and thus the download will lose its resumability
                    {
                        _logger.LogMessage("Not Resumable");
                        existingLength = 0;
                        downloadResumable = false;
                    }

                    OnResumabilityChanged(new DownloadStatusChangedEventArgs(downloadResumable));

                    using var saveFileStream = fileInfo.Open(downloadResumable ? FileMode.Append : FileMode.Create,
                        FileAccess.Write);
                    using var stream = response.GetResponseStream();
                    var downBuffer = new byte[4096];
                    var byteSize = 0;
                    var totalReceived = byteSize + existingLength;
                    var sw = Stopwatch.StartNew();
                    while (!stop && (byteSize = stream.Read(downBuffer, 0, downBuffer.Length)) > 0)
                    {
                        saveFileStream.Write(downBuffer, 0, byteSize);
                        totalReceived += byteSize;

                        var currentSpeed = totalReceived / (float) sw.Elapsed.TotalSeconds;
                        OnProgressChanged(
                            new DownloadProgressChangedEventArgs(totalReceived, fileSize, (long) currentSpeed));

                        pauseLock.Wait();
                        pauseLock.Release();
                    }

                    sw.Stop();
                }

                if (!stop) OnCompleted(EventArgs.Empty);
            }
            catch (System.IO.IOException eio)
            {
                _logger.LogMessage(eio.Message);
                Pause();
                Resume();
            }
            catch (WebException e)
            {
                _logger.LogMessage(e.Message);
            }
        }

        public void Pause()
        {
            if (Paused) return;
            Paused = true;
            // Note this cannot block for more than a moment
            // since the download thread doesn't keep the lock held
            pauseLock.Wait();
        }

        public void Resume()
        {
            if (!Paused) return;
            Paused = false;
            pauseLock.Release();
        }

        public void StopDownload()
        {
            stop = true;
            Resume(); // stop waiting on lock if needed
        }

        protected virtual void OnResumabilityChanged(DownloadStatusChangedEventArgs e)
        {
            ResumablityChanged?.Invoke(this, e);
        }

        protected virtual void OnProgressChanged(DownloadProgressChangedEventArgs e)
        {
            ProgressChanged?.Invoke(this, e);
        }

        protected virtual void OnCompleted(EventArgs e)
        {
            Completed?.Invoke(this, e);
        }
    }

    public class DownloadStatusChangedEventArgs : EventArgs
    {
        public DownloadStatusChangedEventArgs(bool canResume)
        {
            ResumeSupported = canResume;
        }

        public bool ResumeSupported { get; }
    }

    public class DownloadProgressChangedEventArgs : EventArgs
    {
        public DownloadProgressChangedEventArgs(long totalReceived, long fileSize, long currentSpeed)
        {
            BytesReceived = totalReceived;
            TotalBytesToReceive = fileSize;
            CurrentSpeed = currentSpeed;
        }

        public long BytesReceived { get; }
        public long TotalBytesToReceive { get; }
        public float ProgressPercentage => BytesReceived / (float) TotalBytesToReceive * 100;
        public float CurrentSpeed { get; } // in bytes

        public TimeSpan TimeLeft
        {
            get
            {
                var bytesRemainingtoBeReceived = TotalBytesToReceive - BytesReceived;
                return TimeSpan.FromSeconds(bytesRemainingtoBeReceived / CurrentSpeed);
            }
        }
    }
}