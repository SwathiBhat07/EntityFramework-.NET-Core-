using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BulkyBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db; 

        public CategoryController(ApplicationDbContext db) //this will retrieve the Db contents
        {
            _db = db;
        }

        public IActionResult Index()
        {
            //IEnumerable<Category> CategoryList = _db.Categories; //Used Ienumerable to display all the categories
            //return View(CategoryList);
            //Using List datatype
            var List = _db.Categories.Select(x => new Category {
                Id = x.Id,
                Name = x.Name,
                DisplaySeq = x.DisplaySeq
            }).ToList();

            ViewBag.List = List;
            return View(ViewBag.List);
        }
        //GET
        public IActionResult Create()
        {
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if (category.Name == category.DisplaySeq.ToString())
            {
                ModelState.AddModelError("CustomError", "The name and displayseq should not be same");//server side validation
            }
            if(ModelState.IsValid)
            {
                _db.Categories.Add(category);
                _db.SaveChanges();
                TempData["success"] = "Category created successfully!!";
                return RedirectToAction("Index");
            }
            return View(category);
        }
        //GET
        public IActionResult Edit(int ? id)
        {
            if(id==null || id == 0)
            {
                return NotFound();
            }
            var objcategory = _db.Categories.Find(id);
            //var categoryFirst = _db.Categories.FirstOrDefault(u => u.Id == id);
            //var categoryFirst = _db.Categories.SingleOrDefault(u => u.Id == id);
            if(objcategory == null)
            {
                return NotFound();
            }
            return View(objcategory);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            if (category.Name == category.DisplaySeq.ToString())
            {
                ModelState.AddModelError("CustomError", "The name and displayseq should not be same");//server side validation
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Update(category);
                _db.SaveChanges();
                TempData["success"] = "Category updated successfully!!";
                return RedirectToAction("Index");
            }
            return View(category);
        }
        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var objcategory = _db.Categories.Find(id);
            //var categoryFirst = _db.Categories.FirstOrDefault(u => u.Id == id);
            //var categoryFirst = _db.Categories.SingleOrDefault(u => u.Id == id);
            if (objcategory == null)
            {
                return NotFound();
            }
            return View(objcategory);
        }
        //POST
        [HttpPost]//,ActionName("Delete")] //excplict way for giving the method name
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
               var objcategory = _db.Categories.Find(id);
            if (objcategory == null )
            {
                return NotFound();
            }
         

            _db.Categories.Remove(objcategory);
                _db.SaveChanges();
            TempData["success"] = "Category deleted successfully!!";
            return RedirectToAction("Index");
           
         }
    }
}
