using kASHOP.Data;
using Microsoft.AspNetCore.Mvc;

namespace kASHOP.Areas.User.Controllers
{
    [Area("User")]
    public class HomeController : Controller
    {
        ApplicationDbContext context=new ApplicationDbContext();
        public IActionResult Index()
        {

            var categories = context.Categories.ToList();
            return View(categories);
        }
    }
}
