#region License
// Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// email: koroten@ya.ru
// skype:vladimir-korotenko 
// https://vkorotenko.ru
// Создано:  19.08.2019 20:44
#endregion

using System.Globalization;
using System.Linq;
using FiasServer.Code;
using FiasServer.Models;
using Microsoft.AspNetCore.Mvc;

namespace FiasServer.Controllers
{


    /// <summary>
    /// Адресный контроллер. Занимается всеми вопросами связанными с адресами, регионами и прочим.
    /// </summary>
    [Route("api/address")]
    [ApiController]
    public class AddressController : Controller
    {
        private static readonly Country[] Countryes = new Country[]
        {
            new Country{Id = 643,
                Alpha2 = "RU",
                Alpha3 = "RUS",
                Name = "Russia"},
        };
        private readonly Region[] _regions = RegionsSingleton.Instance.Items;
        private readonly City[] _cities = CitiesSingleton.Instance.Items;
        /// <summary>
        /// Список стран в системе.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ResponseCache(Location = ResponseCacheLocation.Any, Duration = 86000)]
        public IActionResult Get()
        {
            return Ok(Countryes);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="country"></param>
        /// <returns></returns>
        [HttpGet("{country}")]
        [ResponseCache(Location = ResponseCacheLocation.Any, Duration = 86000)]
        public ActionResult<Country> Get(string country)
        {
            var res = Countryes.FirstOrDefault(x => x.Alpha2 == country.ToUpper(CultureInfo.InvariantCulture));
            if (res == null)
                return NotFound(new { error = "Not found country" });
            return res;
        }
        /// <summary>
        /// Список регионов для страны.
        /// </summary>
        /// <param name="country"></param>
        /// <returns></returns>
        [HttpGet("{country}/regions")]
        [ResponseCache(Location = ResponseCacheLocation.Any, Duration = 86000)]
        public ActionResult GetRegions(string country)
        {
            var res = Countryes.FirstOrDefault(x => x.Alpha2 == country.ToUpper(CultureInfo.InvariantCulture));
            if (res == null)
                return NotFound(new { error = "Not found country" });
            if (res.Alpha2 == "RU")
                return Ok(_regions);
            return NoContent();
        }
        /// <summary>
        /// Список городов для страны. Только Россия. Первым идет спец объект "Вся Россия", потом Москва и Санкт-Петербург, дальше сортировка по коду.
        /// </summary>
        /// <param name="country">Код страны, ru</param>
        /// <param name="query">Поисковая фраза, по умолчанию все</param>
        /// <param name="limit">Лимит для запроса</param>
        /// <returns></returns>
        [HttpGet("{country}/cities")]
        [ResponseCache(Location = ResponseCacheLocation.Any, Duration = 86000)]
        public ActionResult GetCities(string country, [FromQuery] string query = "", [FromQuery] int limit = 10)
        {
            var res = Countryes.FirstOrDefault(x => x.Alpha2 == country.ToUpper(CultureInfo.InvariantCulture));
            if (res == null)
                return NotFound(new { error = "Not found country" });
            if (res.Alpha2 == "RU")
            {
                return Ok(GetFilteredCityList(query, limit));
            }
            return NoContent();
        }
        /// <summary>
        /// Отдает лимитированное количество городов.
        /// </summary>
        /// <param name="query">Если строка не пустая то применяется фильтр</param>
        /// <param name="limit"></param>
        /// <returns></returns>
        private City[] GetFilteredCityList(string query, int limit)
        {
            if (string.IsNullOrEmpty(query))
                return _cities.Take(limit).ToArray();

            return _cities.Where(x => x.Name.Contains(query, System.StringComparison.InvariantCultureIgnoreCase) ||
                                      x.Slug.Contains(query, System.StringComparison.InvariantCultureIgnoreCase))
                          .Take(limit)
                          .ToArray();
        }
    }
}