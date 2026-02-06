using kASHOP.Data;
using kASHOP.Models;
using kASHOP.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace kASHOP.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class ProductsController : Controller
    {

        ApplicationDbContext context=new ApplicationDbContext();
        public IActionResult Index()
        {
            //p.Category navigation property يعني هون بحمل معاها الداتا التابعه لكل منتج
            //domain model يعني الكلاس اللي بيمثل الجدول في قاعدة البيانات
            var products = context.Products.Include(p=>p.Category).ToList();
            //view model يعني كلاس بسيط بيحتوي على البيانات اللي بدي اعرضها في الواجهة فقط
            var productViewModels =new List<ProductViewModel>();
            foreach(var product in products)
            {
                var productViewModel = new ProductViewModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Image = $"/images/{product.Image}"
                };
                productViewModels.Add(productViewModel);
            }
            return View(productViewModels);
        }
        public IActionResult Create()
        {

            //ViewData["categories"] = context.Categories.ToList();
            ViewBag.categories = context.Categories.ToList();
            return View();
        }
        public IActionResult Store(Product product, IFormFile Image)
        {
           if(Image!=null&&Image.Length>0)
            {
         var fileName=Guid.NewGuid().ToString() ; 
                fileName+=Path.GetExtension(Image.FileName);
                // إنشاء اسم ملف عشوائي مع الاحتفاظ بامتداد الصورة الأصلي، ثم تحديد مسار الحفظ داخل wwwroot/images
                var filePath =Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\images",fileName);
                using (var stream=System.IO.File.Create(filePath))
                {
                    // حفظ الصورة في المسار المحدد باستخدام FileStream
                    Image.CopyTo(stream);
                }
                product.Image = fileName; // حفظ اسم الملف في قاعدة البيانات
                context.Products.Add(product);
                context.SaveChanges();
                 return RedirectToAction("Index");


            }
        
            return Content("ok");

        }
    }
}
