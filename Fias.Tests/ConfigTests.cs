#region License

// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  06.06.2020 22:06

#endregion

using VKorotenko.Poco;
using Xunit;

namespace Fias.Tests
{
    public class ConfigTests
    {
        [Fact]
        public void SaveTest()
        {
            var path = "test.xml";
            var config = new Config()
            {
                FullPath = @"v:\FIAS\data\fias.zip",
                ConnectionString = "",
                DbBackEnd = "MSSQL",
                Override = true,
                Swap = false

            };
            Config.Save(path,config);

        }
        [Fact]
        public void LoadTest()
        {
            var path = "test.xml";
            var config = Config.Load(path);
        }
    }
}