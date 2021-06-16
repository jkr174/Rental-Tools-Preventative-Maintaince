using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheDeepO.Models
{
    public class EFInventoryRepository : IInventoryRepository
    {
        private ApplicationDbContext context;
        public EFInventoryRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Inventory> Inventories => context.Inventories;

        public void SaveItem(Inventory inventory)
        {
            if(inventory.ItemID == 0)
            {
                context.Inventories.Add(inventory);
            }
            else
            {
                Inventory dbEntry = context.Inventories
                    .FirstOrDefault(i => i.ItemID == inventory.ItemID);
                if(dbEntry != null)
                {
                    dbEntry.ItemIdentifier = inventory.ItemIdentifier;
                    dbEntry.ItemName = inventory.ItemName;
                    dbEntry.Description = inventory.Description;
                    dbEntry.Price = inventory.Price;
                    dbEntry.Category = inventory.Category;
                    dbEntry.Subcategory = inventory.Subcategory;
                    dbEntry.OnHandQty = inventory.OnHandQty;
                    dbEntry.OutQty = inventory.OutQty;
                    dbEntry.TotalQty = inventory.TotalQty;
                }
            }
            context.SaveChanges();
        }
        public Inventory DeleteItem(int itemID)
        {
            Inventory dbEntry = context.Inventories
                .FirstOrDefault(i => i.ItemID == itemID);
            if(dbEntry != null)
            {
                context.Inventories.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}

