using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheDeepO.Models
{
    public interface IInventoryRepository
    {
        IQueryable<Inventory> Inventories { get; }
        void SaveItem(Inventory inventory);
        Inventory DeleteItem(int itemID);
    }
}
