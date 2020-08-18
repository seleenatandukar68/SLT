using SLT.Interface;
using SLT.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI.WebControls;
using Color = SLT.Models.Color;

namespace SLT.DAL
{
    public class SLTRepository : ISLTRepository
    {
        SLTDbContext SLTDbContext = new SLTDbContext();
        public Bag AddBag(Bag newBag)
        {
           Bag intBag = SLTDbContext.Bags.Add(newBag);
           return intBag;
            
        }

        public IEnumerable<BagsColors> GetBagsColors()
        {

            return SLTDbContext.BagsColors.Include("Bag").Include("Color").ToList();
         //   var lstBagColor = SLTDbContext.Bags.
         //SelectMany(b => b.BagsColors.Select(c => new { b, c })).Include("Colors").
         //Select(s => new BagsColors
         //{
            
         //    BagId = s.b.BagId,
         //    ColorId = s.c.ColorId,
         //    Bag = s.b,
         //    Color = s.c.Color
         //});
         //   return lstBagColor;
        }

     
    }
}