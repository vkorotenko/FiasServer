#region License

// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  01.06.2020 12:34

#endregion

using System.Diagnostics;
using System.IO;
using VKorotenko.FiasServer.Bl.Download;
using VKorotenko.FiasServer.Bl.Loggers;
using Xunit;

namespace Fias.Tests
{
    public class FetcherTest
    {
        [Fact]
        public async void FetchLatestTest()
        {
            var data = await Fetcher.GetLatestAsync();
        }
        [Fact]
        public async void FetchAllTest()
        {
            var data = await Fetcher.GetAllAsync();
            ;
        }
        [Fact]
        public async void FetchLatestDelta()
        {
            var data = await Fetcher.GetLatestAsync();
            var path = "latest.xml";
            Fetcher.GetXmlDelta(data, path);
            ;
        }

        [Fact]
        public async void FetchFile()
        {
            var data = await Fetcher.GetAllAsync();
            var prev = data[0];
            var fileName = "deltaXML.zip";
            var version = prev.VersionId.ToString();
            if (!Directory.Exists(version))
                Directory.CreateDirectory(version);


            var client = new RenewableClient(Path.Combine(version, fileName), prev.FiasDeltaXmlUrl);
            client.BlockComplete += (s, e) => Debug.WriteLine($"Downloaded: {e.Received:N}");
            client.Download();

            ;
        }
        [Fact]
        public async void FetchFileDownloadTest()
        {
            var data = await Fetcher.GetAllAsync();
            var prev = data[0];
            var fileName = "deltaXML.zip";
            var version = prev.VersionId.ToString();
            if (!Directory.Exists(version))
                Directory.CreateDirectory(version);


            var client = new Download(new DebugLogger());
            client.ProgressChanged += (s, e) => Debug.WriteLine($"Downloaded: {e.BytesReceived:N} {e.ProgressPercentage:N} %");
            client.DownloadFile(prev.FiasDeltaXmlUrl, Path.Combine(version, fileName));

            ;
        }
    }
}