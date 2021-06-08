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
    }
}

