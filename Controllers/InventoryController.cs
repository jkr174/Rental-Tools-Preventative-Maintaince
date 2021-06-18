using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TheDeepO.Models;
using TheDeepO.Models.ViewModels;

namespace TheDeepO.Controllers
{
    public class InventoryController : Controller
    {
        private IInventoryRepository repository;
        public int PageSize = 4;
        private readonly ApplicationDbContext _context;

        public InventoryController(IInventoryRepository repo, ApplicationDbContext context)
        {
            repository = repo;
            _context = context;
        }
        public ViewResult List(string category, string searchString, int inventoryPage = 1)
            => View(new InventoryListViewModel
            {


                Inventories = repository.Inventories
                .Where(i => category == null || i.Category == category)
                .OrderBy(i => i.ItemID)
                .Skip((inventoryPage - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = inventoryPage,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ?
                    repository.Inventories.Count() :
                    repository.Inventories.Where(e =>
                    e.Category == category).Count()
                },
                CurrentCategory = category
            }
            );
        public async Task<IActionResult> Index(string searchString)
        {
            var inventory = from i in _context.Inventories select i;

            if (!String.IsNullOrEmpty(searchString))
            {
                inventory = inventory.Where(s => s.ItemName.Contains(searchString));
            }

            return View(await inventory.ToListAsync());
        }
    }
}
