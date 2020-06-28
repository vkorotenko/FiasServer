using Newtonsoft.Json;
using VKorotenko.Poco;

namespace VKorotenko.Dbl
{
    public class Dumper
    {
        public static void SaveCityListToJson(string path, City[] reg)
        {
            var result = JsonConvert.SerializeObject(reg, Formatting.Indented);
            System.IO.File.WriteAllText(path, result);
        }

        public static void SaveRegionListToJson(string path, Region[] reg)
        {
            var result = JsonConvert.SerializeObject(reg, Formatting.Indented);
            System.IO.File.WriteAllText(path, result);
        }
    }
}
