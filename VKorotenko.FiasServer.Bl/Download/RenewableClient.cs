#region License

// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  01.06.2020 20:32

#endregion

using System;
using System.Diagnostics;
using System.IO;
using System.Net;

namespace VKorotenko.FiasServer.Bl.Download
{
    public class RenewableClient : IDisposable
    {
        private const int BlockSize = 8 * 1024;
        private readonly string _path;
        private readonly string _url;
        private FileStream _fs;
        private long _pos;
        private long _responseLength;
        private long _received;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="url"></param>
        public RenewableClient(string path, string url)
        {
            _url = url;
            _path = path;
            InitFile(_path);
        }

        /// <summary>
        /// Прекратить попытки скачивания после заданного числа ошибок.
        /// Значение по умолчанию 10. Увеличите количество при нестабильности сервера.
        /// </summary>
        public int DropAfter { get; set; } = 10;

        public void Dispose()
        {
            _fs?.Dispose();
        }
        /// <summary>
        /// Скачивание завершено.
        /// </summary>
        public event Complete Complete;

        private void OnComplete()
        {
            Complete?.Invoke(this, new CompleteArgs(_path, _url, DateTime.Now));
        }
        /// <summary>
        /// Скачивание блока завершено
        /// </summary>
        public event BlockComplete BlockComplete;

        private void OnBlockComplete(long size, long rec)
        {
            BlockComplete?.Invoke(this, new BlockCompleteArgs(rec, size));
        }

        private void InitFile(string path)
        {
            if (File.Exists(path))
            {
                _fs = File.OpenWrite(path);
                _pos = _fs.Length;
                _fs.Seek(_pos, SeekOrigin.Current);
            }
            else
            {
                _fs = new FileStream(path, FileMode.Create);
                _pos = 0;
            }

            _received = _pos;
        }
        /// <summary>
        /// Начать скачивание файла. 
        /// </summary>
        public void Download()
        {
            try
            {
                GetFileSize();
                var request = (HttpWebRequest)WebRequest.Create(_url);
                request.AddRange(_pos, _responseLength - 1);
                var rsp = request.GetResponse();
                var ns = rsp.GetResponseStream();

                var buffer = new byte[BlockSize];
                var readSize = 0;
                readSize = ns.Read(buffer, 0, BlockSize);

                while (readSize > 0)
                {
                    _fs.Write(buffer, 0, readSize);
                    _received += readSize;
                    OnBlockComplete(BlockSize, _received);
                    readSize = ns.Read(buffer, 0, BlockSize);
                }

                _fs.Close();
                ns.Close();
                OnComplete();
            }

            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                _fs.Close();
                if (DropAfter > 0)
                {
                    InitFile(_path);
                    DropAfter--;
                    Download();
                }
            }
        }

        private void GetFileSize()
        {
            var webRequest = WebRequest.Create(_url);
            webRequest.Method = "HEAD";

            using var webResponse = webRequest.GetResponse();
            _responseLength = long.Parse(webResponse.Headers.Get("Content-Length"));
        }
    }
    /// <summary>
    /// Делегат завершения скачивания
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    public delegate void Complete(object sender, CompleteArgs args);

    /// <summary>
    /// Делегат для скачивания блока.
    /// </summary>
    /// <param name="sender">Отправитель</param>
    /// <param name="args">Параметры скачанного блока</param>
    public delegate void BlockComplete(object sender, BlockCompleteArgs args);
}