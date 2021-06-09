using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheDeepO.Models;

namespace TheDeepO.Controllers
{
    public class AdminController : Controller
    {
        private IInventoryRepository repository;

        public AdminController(IInventoryRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index() => View(repository.Inventories);
        public ViewResult Edit(int itemId) =>
            View(repository.Inventories
                .FirstOrDefault(i => i.ItemID == itemId));

        [HttpPost]
        public IActionResult Edit(Inventory inventory)
        {
            if (ModelState.IsValid)
            {
                repository.SaveItem(inventory);
                TempData["message"] = $"{inventory.ItemName} has been saved.";
                return RedirectToAction("Index");
            }
            else
            {
                // Something was wrong with the data entry(s)
                return View(inventory);
            }
        }
        public ViewResult Create() => View("Edit", new Inventory());

        [HttpPost]
        public IActionResult Delete(int itemId)
        {
            Inventory deletedItem = repository.DeleteItem(itemId);
                {
                if(deletedItem != null)
                {
                    TempData["message"] = $"{deletedItem.ItemName} was deleted.";
                }
                return RedirectToAction("Index");
            }
        }
    }
}
