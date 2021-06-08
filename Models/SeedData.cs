using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace TheDeepO.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices
                .GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();

            //context.Database.Migrate();
            if (!context.Inventories.Any())
            {
                context.Inventories.AddRange(
                    new Inventory
                    {
                        ItemName = "Makita 36V Cordless Chainsaw 14 inch",
                        Description = "A chainsaw for cuitting down trees.",
                        Category = "Cutters", //Category 1
                        Price = 48.00m //Per Day
                    },
                    new Inventory
                    {
                        ItemName = "Makita Breaker",
                        Description = "Jackhammers, the combination of a hammer and a chisel.",
                        Category = "Breakers", //Category 2
                        Price = 91.00m //Per Day
                    },
                    new Inventory
                    {
                        ItemName = "Honda 6500 Watt Generator",
                        Description = "In case of an emergency, so you're not out of power.",
                        Category = "Generators", //Category 3
                        Price = 85.00m //Per Day
                    },
                    new Inventory
                    {
                        ItemName = "Automatic Drain Cleaner 100' X 5/8 inches",
                        Description = "Got something stuck in your pipe system? Look no more.",
                        Category = "Drain Cleaners", //Category 4
                        Subcategory = "75 ft", //Subcategorized by size and length
                        Price = 96.00m //Per Day
                    },
                    new Inventory
                    {
                        ItemName = "DeWalt 20V Framer Nail Gun",
                        Description = "Flat-packed 35,000-seat stadium",
                        Category = "Air Compressors and Nail Guns", //Category 5
                        Subcategory = "Eletric Nail Guns",
                        Price = 29.00m //Per Day
                    },
                    new Inventory
                    {
                        ItemName = "Mi-T-M Eletric Pressure Washer",
                        Description = "Can be used to quickly clean your house.",
                        Category = "Pressure Washers", //Category 10
                        Subcategory = "1400 PSI", //Subcategorized by Pressure
                        Price = 39.00m //Per Day
                    },
                    new Inventory
                    {
                        ItemName = "Makita Backpack Blower",
                        Description = "Get rid of those pesky leaves.",
                        Category = "Leafblowers", // Category 8
                        Price = 44.00m
                    },
                    new Inventory
                    {
                        ItemName = "Clarke American Sanders Floor Maintainer",
                        Description = "Have your floor looking shiny.",
                        Category = "Floor Cleaners", // Category 9
                        Subcategory = "Floor Polishers",
                        Price = 61.00m
                    },
                    new Inventory
                    {
                        ItemName = "19ft Scissor Lift",
                        Description = "How to give someone a fear of heights.",
                        Category = "Large Eqiupment", // Category 10
                        Subcategory = "Ariel Equipment",
                        Price = 159.00m // PerDay
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
