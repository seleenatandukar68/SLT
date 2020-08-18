namespace SLT.Migrations
{
    using SLT.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SLT.SLTDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "SLT.SLTDbContext";
        }

        protected override void Seed(SLT.SLTDbContext dbContext)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            var bagCategories = new List<Category>
            {
                new Category {CatName = "PartyBags"},
                new Category {CatName = "ShoppingBags"},
                new Category {CatName = "SideBags"}
            };
            bagCategories.ForEach(c => dbContext.Categories.AddOrUpdate(cat => cat.CatName, c));
            dbContext.SaveChanges();
            //Seeding bags 
            var bags = new List<Bag>
            {
            new Bag{BagBrand="LV", Cost =100, CategoryId=1},
            new Bag{BagBrand = "Channel", Cost = 2000,CategoryId =2}
            };

            bags.ForEach(b => dbContext.Bags.AddOrUpdate(p => p.BagBrand, b));
            dbContext.SaveChanges();

            //seeding colors
            var colors = new List<Color>
            {
            new Color{ ColorName ="Red"},
            new Color{ ColorName ="Green"},
            new Color{ ColorName ="Yellow"}
            };

            colors.ForEach(c => dbContext.Colors.AddOrUpdate(p=>p.ColorName, c));
            dbContext.SaveChanges();

            //seeding bagcolor
            var bagsColors = new BagsColors[] {
            new BagsColors
            {
                BagId = bags.Single(b =>b.BagBrand == "Channel").BagId,
                ColorId = colors.Single(c => c.ColorName== "Red").Id
            } ,
            new BagsColors
            {
                BagId = bags.Single(b =>b.BagBrand == "LV").BagId,
                ColorId = colors.Single(c => c.ColorName== "Green").Id
            },

            };
            foreach (BagsColors bc in bagsColors)
            {
                dbContext.BagsColors.AddOrUpdate(bc);
            }

            dbContext.SaveChanges();


            base.Seed(dbContext);
        }
    }
}
