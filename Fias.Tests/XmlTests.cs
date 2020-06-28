#region License

// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  07.06.2020 20:54

#endregion

using System.IO;
using System.Xml.Serialization;
using VKorotenko.FiasServer.Bl.Dictionary;
using Xunit;

namespace Fias.Tests
{
    public class XmlTests
    {
        private string _basePath = @"V:\project\FiasServer\VKorotenko.FiasServer.Bl\XMLS";
        [Fact]
        public void ActStatus()
        {
            var name = "AS_ACTSTAT_20200531_eaa04ab1-d387-4c01-a465-99eb611fe1ba.XML";
            var fp = Path.Combine(_basePath, name);
            var formatter = new XmlSerializer(typeof(ActualStatus[]), new XmlRootAttribute(ActualStatus.Root));
            using var fs = new FileStream(fp, FileMode.OpenOrCreate);
            var statuses =  (ActualStatus[])formatter.Deserialize(fs);
            Assert.Equal(2,statuses.Length);
        }
    }
}