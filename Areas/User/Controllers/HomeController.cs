using kASHOP.Data;
using kASHOP.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public IActionResult IndexProduct()
        {
           
            var products = context.Products.ToList();
            var productViewModels = new List<ProductViewModel>();
            foreach (var product in products)
            {
                var productViewModel = new ProductViewModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Image = $"/images/{product.Image}"
                   , Price = product.Price
                };
                productViewModels.Add(productViewModel);
            }
            return View("IndexProduct",productViewModels);
        }
    }
}
