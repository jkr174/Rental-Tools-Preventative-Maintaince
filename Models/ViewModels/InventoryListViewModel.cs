using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheDeepO.Models.ViewModels
{
    public class InventoryListViewModel
    {
        public IEnumerable<Inventory> Inventories { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
        public string CurrentSubcategory { get; set; }
    }
}
