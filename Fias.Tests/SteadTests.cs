#region License
// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  04.07.2020 8:35
#endregion

using System;
using VKorotenko.FiasServer.Bl.Data;
using Xunit;

namespace Fias.Tests
{
    public class SteadTests
    {
        [Fact]
        void WrongStead()
        {
            var result = @"<Stead STEADGUID=""7b25c696-e425-43c8-b065-a7a985158db6"" NUMBER=""20Д"" REGIONCODE=""22"" POSTALCODE=""658047"" IFNSFL=""2208"" IFNSUL=""2208"" TERRIFNSFL=""2263"" TERRIFNSUL=""2263"" OKATO=""01232820001"" UPDATEDATE=""2017-03-07"" PARENTGUID="""" STEADID=""7b25c696-e425-43c8-b065-a7a985158db6"" OPERSTATUS=""10"" STARTDATE=""2010-02-01"" ENDDATE=""2010-02-02"" NEXTID=""3930b99c-b6b8-421f-ab04-bbf6ab6acd68"" OKTMO=""01632420101"" LIVESTATUS=""0"" DIVTYPE=""0"" NORMDOC=""40c9847c-ec60-444a-8e88-d0f59b8f0608""  />";
            var sbs = result.Substring(214);
            var ret = Guid.Parse("");
            
            var c = new Stead(result);

        }
    }
}
