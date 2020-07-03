#region License
// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  28.06.2020 15:18
#endregion


using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using VKorotenko.FiasServer.Bl.PureData;
using Xunit;

namespace Fias.Tests
{
    public class AddressTests
    {
        [Fact]
        void DesirualizeNormTest()
        {
            var anorm = @"XML\anorm.xml";
            var formatter = new XmlSerializer(typeof(XmlAddressObject[]), new XmlRootAttribute(XmlAddressObject.Root));
            using var fs = new FileStream(anorm, FileMode.OpenOrCreate);
            var addressObjects = (XmlAddressObject[])formatter.Deserialize(fs);
            var complite = addressObjects.Select(XmlAddressObject.Get);
            /* <Object
             AOID="a03a0011-2bd1-4be1-9693-1f03bf0cff3b" 
            AOGUID="9f1204de-c03f-48ba-a023-16a904e9a9cf" 
            PARENTGUID="c012d402-217c-488a-85f3-52b3312ddab6" 
            NEXTID="124f33a1-aea9-4507-ac48-04a9e51500fc" 
            FORMALNAME="Чкалова" 
            OFFNAME="Чкалова" 
            SHORTNAME="ул" 
            AOLEVEL="7" 
            REGIONCODE="87" 
            AREACODE="003" 
            AUTOCODE="0" 
            CITYCODE="001" 
            CTARCODE="000" 
            PLACECODE="000" 
            PLANCODE="0000" 
            STREETCODE="0060" 
            EXTRCODE="0000" 
            SEXTCODE="000" 
            PLAINCODE="870030010000060" 
            CODE="87003001000006001" 
            CURRSTATUS="1" 
            ACTSTATUS="0" 
            LIVESTATUS="0" 
            CENTSTATUS="0" 
            OPERSTATUS="1" 
            IFNSFL="8706" 
            IFNSUL="8706" 
            TERRIFNSFL="8703" 
            TERRIFNSUL="8703" 
            OKATO="77209501000" 
            OKTMO="77609101" 
            POSTALCODE="689450" 
            STARTDATE="1900-01-01" 
            ENDDATE="2019-01-04" 
            UPDATEDATE="2019-01-10" 
            DIVTYPE="0" /> */
            Assert.Equal(138, addressObjects.Length);
        }
        [Fact]
        void FullParseTest()
        {
            var data = @"v:\FIAS\data\fias.zip";
            using var archive = ZipFile.OpenRead(data);
            foreach (var entry in archive.Entries)
            {
                if (entry.Name.ToUpperInvariant().StartsWith(XmlAddressObject.Start.ToUpperInvariant()))
                {
                    using var stream = entry.Open();
                    XmlReader _reader;
                    var settings = new XmlReaderSettings() { };

                    _reader = XmlReader.Create(stream, settings);

                    while (_reader.Read())
                    {
                        switch (_reader.NodeType)
                        {
                            case XmlNodeType.Element:
                                if (_reader.Name == XmlAddressObject.ContainerTag)
                                {
                                    try
                                    {
                                        if (_reader.HasAttributes)
                                        {

                                            var xml =  new StringBuilder();
                                            // xml.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
                                            
                                            xml.Append($"<{_reader.Name} ");
                                            while (_reader.MoveToNextAttribute())
                                            {
                                                xml.Append($"{_reader.Name}=\"{_reader.Value}\" ");
                                            }

                                            xml.Append(" />");
                                            
                                            // <Object AOID="a03a0011-2bd1-4be1-9693-1f03bf0cff3b" AOGUID="9f1204de-c03f-48ba-a023-16a904e9a9cf" PARENTGUID="c012d402-217c-488a-85f3-52b3312ddab6" NEXTID="124f33a1-aea9-4507-ac48-04a9e51500fc" FORMALNAME="Чкалова" OFFNAME="Чкалова" SHORTNAME="ул" AOLEVEL="7" REGIONCODE="87" AREACODE="003" AUTOCODE="0" CITYCODE="001" CTARCODE="000" PLACECODE="000" PLANCODE="0000" STREETCODE="0060" EXTRCODE="0000" SEXTCODE="000" PLAINCODE="870030010000060" CODE="87003001000006001" CURRSTATUS="1" ACTSTATUS="0" LIVESTATUS="0" CENTSTATUS="0" OPERSTATUS="1" IFNSFL="8706" IFNSUL="8706" TERRIFNSFL="8703" TERRIFNSUL="8703" OKATO="77209501000" OKTMO="77609101" POSTALCODE="689450" STARTDATE="1900-01-01" ENDDATE="2019-01-04" UPDATEDATE="2019-01-10" DIVTYPE="0" />
                                            var result = xml.ToString();
                                            var c = new XmlAddressObject(result);
                                            var n = XmlAddressObject.Get(c);
                                            OnCompanyParsed(this, c);
                                        }
                                    }
                                    catch (Exception e)
                                    {
                                        Debug.WriteLine(e.Message);
                                    }
                                }
                                break;
                        }
                    }

                }
            }
            Assert.Equal(2000, _count);
        }

        private static int _count = 0;
        private void OnCompanyParsed(AddressTests addressTests, XmlAddressObject xmlAddressObject)
        {
            _count++;
        }
        [Fact]
        public void WrongCyrStatusXmlTest()
        {
            var bad = @"<Object AOID=""791047a8-900b-4701-8a3f-42fc59ea659f"" AOGUID=""791047a8-900b-4701-8a3f-42fc59ea659f"" PARENTGUID=""d5697463-639a-492f-8b33-2fb6d988bbcd"" NEXTID=""6df5c419-0487-4771-8b60-ddcb1b966548"" FORMALNAME=""5-я"" OFFNAME=""5-я"" SHORTNAME=""ул"" AOLEVEL=""91"" REGIONCODE=""63"" AREACODE=""000"" AUTOCODE=""0"" CITYCODE=""001"" CTARCODE=""000"" PLACECODE=""000"" PLANCODE=""0000"" STREETCODE=""0000"" EXTRCODE=""0000"" SEXTCODE=""000"" CURRSTATUS="""" ACTSTATUS=""0"" LIVESTATUS=""0"" CENTSTATUS=""0"" OPERSTATUS=""10"" IFNSFL=""6312"" IFNSUL=""6312"" OKATO=""36401368000"" OKTMO=""36701000"" POSTALCODE=""443029"" STARTDATE=""1960-01-01"" ENDDATE=""2016-09-28"" UPDATEDATE=""2020-04-25"" DIVTYPE=""0""  />";
            var c = new XmlAddressObject(bad);
            var t = XmlAddressObject.Get(c);
            Assert.Equal(0,t.CurrStatus);
        }
        [Fact]
        public void WrongTest()
        {
            var bad =
                @"<Object AOID=""1bbc6667-eb67-468f-ac4c-41bacbce64d1"" AOGUID=""71764a50-1328-4f86-874c-66b1ed0444a7"" PARENTGUID=""90c69435-9a82-4965-ac01-d2689e2e535c"" PREVID=""a47f5fa4-a89c-4a4c-8700-7ae639db3761"" NEXTID=""b58debbb-0c64-4382-8e24-b7e46a28650b"" FORMALNAME=""дачного хозяйства &quot;Архангельское&quot;"" OFFNAME=""дачного хозяйства &quot;Архангельское&quot;"" SHORTNAME=""п"" AOLEVEL=""6"" REGIONCODE=""50"" AREACODE=""013"" AUTOCODE=""0"" CITYCODE=""000"" CTARCODE=""000"" PLACECODE=""054"" PLANCODE=""0000"" STREETCODE=""0000"" EXTRCODE=""0000"" SEXTCODE=""000"" PLAINCODE=""50013000054"" CODE=""5001300005406"" CURRSTATUS=""6"" ACTSTATUS=""0"" LIVESTATUS=""0"" CENTSTATUS=""0"" OPERSTATUS=""20"" IFNSFL=""5024"" IFNSUL=""5024"" OKATO=""46223802002"" OKTMO=""46623404136"" POSTALCODE=""143420"" STARTDATE=""2017-11-20"" ENDDATE=""2018-01-16"" UPDATEDATE=""2018-01-16"" NORMDOC=""0f71f6c6-390c-44db-9624-5eca1e40c2e6"" DIVTYPE=""0""  />";
            var c = new XmlAddressObject(bad);
            var t = XmlAddressObject.Get(c);
        }
    }
}
