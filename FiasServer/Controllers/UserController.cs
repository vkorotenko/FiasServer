#region License

// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  04.08.2020 9:32

#endregion

using Microsoft.AspNetCore.Mvc;

namespace FiasServer.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : Controller
    {
        [HttpGet("info")]
        public IActionResult Info()
        {
            return Json(new { data = "test" });
        }
    }
}