using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheDeepO.Models
{
    public class FakeInventoryRepository : IInventoryRepository
    {
        public IQueryable<Inventory> Inventories => new List<Inventory> {
            new Inventory { ItemIdentifier = "PT-CH-1", ItemName = "Chainsaw", Price = 25 },
            new Inventory { ItemIdentifier = "BR-HR-1", ItemName= "ROTO Hammer", Price = 12 },
            new Inventory { ItemIdentifier = "GN-20-1", ItemName = "2000 Watt Generator", Price = 95 }
        }.AsQueryable<Inventory>();
    }
}
