#region License
// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  02.08.2020 10:37
#endregion

using FiasServer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FiasServer.Controllers
{

    [Authorize(Roles = "Administrator")]
    // [Authorize]
    [ApiController]
    [Route("api/admin")]
    public class AdminController : Controller
    {
        private AdminInfoService _service;

        public AdminController(AdminInfoService service)
        {
            _service = service;
        }
        [HttpGet("info")]
        public IActionResult Info()
        {
            return Json(_service.Model);
        }
    }
}
