using kASHOP.Data;
using kASHOP.Models;
using Microsoft.AspNetCore.Mvc;

namespace kASHOP.Areas.Admin.Controllers
{   
 
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        ApplicationDbContext context=new ApplicationDbContext();
        public IActionResult Index()
        {
            var categories = context.Categories.ToList();
            return View(categories);
        }
        public IActionResult Create()
        {
           
            return View("Create");
        }
     
             public IActionResult Store(Category request)
            {
            if (ModelState.IsValid) {
                context.Categories.Add(request);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));

            }
            return View("Create", request);

        }

        public IActionResult Delete(int id)
        {

            Category category = context.Categories.Find(id);
            context.Categories.Remove(category);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            Category category = context.Categories.Find(id);

            return View(category);
        }
        public IActionResult Update(Category request)
        {
            if (ModelState.IsValid) {
                context.Categories.Update(request);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));

            }
            return View("Edit", request);

        }


    }
}
