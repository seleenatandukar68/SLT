using SLT.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SLT
{
    public class SLTDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Bag> Bags { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Picture> Pictures { get; set; }

        public DbSet<BagsColors> BagsColors { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //modelBuilder.Entity<Bag>().HasMany(bc => bc.Colors).
            //    WithMany(bc => bc.Bags).
            //    Map(m => m
            //    .MapLeftKey("BagId")
            //    .MapRightKey("ColorId")
            //    .ToTable("BagsColors"));

            modelBuilder.Entity<BagsColors>().HasKey(bc => new { bc.BagId,bc.ColorId });
          
            modelBuilder.Entity<Color>().Ignore(c => c.isChecked);
            //modelBuilder.Entity<Bag>()
            //.HasRequired<Category>(c => c.Category)
            //.WithMany(b =>b.Bags )
            //.HasForeignKey<int>(b => b.CategoryId);

            modelBuilder.Entity<Picture>().HasKey(p=> p.PicId)
            .HasRequired<Bag>(c => c.Bag)
            .WithMany(b => b.BagsPictures)
            .HasForeignKey<int>(b => b.BagId);
          

        }

    }
}