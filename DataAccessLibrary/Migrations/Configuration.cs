namespace SLT.Migrations
{
    using SLT.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Linq;
    using System.Text;

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
                new Category {CatName = "Tote Bag"},
                new Category {CatName = "Shopping Bag"},
                new Category {CatName = "Shoulder Bag"}
            };
            bagCategories.ForEach(c => dbContext.Categories.AddOrUpdate(cat => cat.CatName, c));
            SaveChanges(dbContext);
            //Seeding bags 
            var bags = new List<Bag>
            {
            new Bag{BagBrand="LV", Cost =1000,sellCost= 1500,Quantity=50, CategoryId=1},
            new Bag{BagBrand = "Channel", Cost = 2000,sellCost= 2500,Quantity=60, CategoryId =2}
            };

            bags.ForEach(b => dbContext.Bags.AddOrUpdate(p => p.BagBrand, b));
            SaveChanges(dbContext);

            //seeding colors
            var colors = new List<Color>
            {
            new Color{ ColorName ="Red"},
            new Color{ ColorName ="Green"},
            new Color{ ColorName ="Yellow"}
            };

            colors.ForEach(c => dbContext.Colors.AddOrUpdate(p=>p.ColorName, c));
            SaveChanges(dbContext);

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

            SaveChanges(dbContext);


            base.Seed(dbContext);
        }

        private void SaveChanges(DbContext context)
        {
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" +
                    sb.ToString(), ex
                ); // Add the original exception as the innerException
            }
        }
    }
}
