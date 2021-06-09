using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheDeepO.Models;

namespace TheDeepO.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IInventoryRepository repository;
        public NavigationMenuViewComponent(IInventoryRepository repo)
        {
            repository = repo;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(repository.Inventories
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x));
        }
    }
}
