﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheDeepO.Models;
using TheDeepO.Models.ViewModels;

namespace SportsStore.Controllers
{
    public class InventoryController : Controller
    {
        private IInventoryRepository repository;
        public int PageSize = 4;

        public InventoryController(IInventoryRepository repo)
        {
            repository = repo;
        }
        public ViewResult List(string category, int inventoryPage = 1)
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
            });
    }
}
