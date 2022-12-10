using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Create()
        {
            return View();
        }
    }
}
