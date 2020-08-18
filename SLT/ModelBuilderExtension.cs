using SLT.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace SLT
{
    public class ModelBuilderExtension : DropCreateDatabaseIfModelChanges<SLTDbContext>
    {

        protected override void Seed(SLTDbContext dbContext)
        {
            //seeding category
            var bagCategories = new List<Category>
            {
                new Category {CatName = "PartyBags"},
                new Category {CatName = "ShoppingBags"},
                new Category {CatName = "SideBags"}
            };
            bagCategories.ForEach(c => dbContext.Categories.AddOrUpdate(cat=> cat.CatName, c));
            dbContext.SaveChanges();
            //Seeding bags 
            var bags = new List<Bag>
            {
            new Bag{BagBrand="LV", Cost =100, CategoryId=1},
            new Bag{BagBrand = "Channel", Cost = 2000,CategoryId =2}
            };

            bags.ForEach(b => dbContext.Bags.AddOrUpdate(p=>p.BagBrand,b));
            dbContext.SaveChanges();

            //seeding colors
            var colors = new List<Color>
            {
            new Color{ ColorName ="Red"},
            new Color{ ColorName ="Green"},
            new Color{ ColorName ="Yellow"}
            };

            colors.ForEach(c => dbContext.Colors.Add(c));
            dbContext.SaveChanges();

            //seeding bagcolor
            var bagsColors = new List<BagsColors>
            {
            new BagsColors{ BagId = 1 , ColorId = 1},
            new BagsColors{ BagId = 1 , ColorId = 2},
            new BagsColors{BagId = 2, ColorId = 3}
            };

            bagsColors.ForEach(c => dbContext.BagsColors.Add(c));
            dbContext.SaveChanges();

           
            base.Seed(dbContext);
        }
       
        
        
    }
}