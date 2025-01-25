using Microsoft.AspNetCore.Mvc;

namespace LMS10_1.Areas.Teacher.Controllers
{
    [Area("Teacher")]
    [Route("Teacher/[controller]/[action]")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
