using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheDeepO.Models;
using TheDeepO.Models.ViewModels;

namespace TheDeepO.Controllers
{
    public class CategoryController : Controller
    {
        public readonly ApplicationDbContext _context;
        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<CategoryClass> categoryList = new List<CategoryClass>();

            categoryList = (from category in _context.Category
                            select category).ToList();
            categoryList.Insert(0, new CategoryClass { CategoryId = 0, Category = "Select" });

            ViewBag.ListofCategory = categoryList;
            return View();
        }
    }
}
