using kASHOP.Data;
using kASHOP.Models;
using Microsoft.AspNetCore.Mvc;

namespace kASHOP.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class ProductsController : Controller
    {

        ApplicationDbContext context=new ApplicationDbContext();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {

            //ViewData["categories"] = context.Categories.ToList();
            ViewBag.categories = context.Categories.ToList();
            return View();
        }
        //public IActionResult Store(Product product,IFormFile image)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        context.Products.Add(product);
        //        context.SaveChanges();

        //    }


        //}
    }
}
