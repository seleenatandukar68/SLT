using SLT.Interface;
using SLT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.ModelBinding;
using System.Data.Entity;
using System.Web.Mvc;
using System.IO;

namespace SLT.DAL
{
    public class BagReporsitory : IBagRepository
    {
        private SLTDbContext SLTDbContext = new SLTDbContext();
        public List<SelectListItem> GetCategories()
        {
            List<SelectListItem> CateList = SLTDbContext.Categories.Select(cl => new SelectListItem
            {
                Selected = false,
                Text = cl.CatName,
                Value = cl.Id.ToString()
            }).ToList();
            var CateListtip = new SelectListItem()
            {
                Value = null,
                Text = "--- Select Category ---"
            };
            CateList.Insert(0, CateListtip);
            return CateList;
        }
        public List<Bag> GetBags()
        {
           
            return
             (from b in SLTDbContext.Bags
              join p in SLTDbContext.Pictures on b.BagId equals p.BagId
              select b).ToList();
        }

        public Bag AddBag (Bag newBag)
        {
            
            SLTDbContext.Bags.Add(newBag);
            SLTDbContext.SaveChanges();
           
            foreach( var item in newBag.ColorList)
            {
                if (item.isChecked == true)
                {
                    BagsColors bc = new BagsColors();
                    bc.BagId = newBag.BagId;
                    bc.ColorId = item.Id;
                    SLTDbContext.BagsColors.Add(bc);
                }
            }
            SLTDbContext.SaveChanges();
            //foreach (var bagPic in newBag.BagsPictures)
            //{
            //    SLTDbContext.Pictures.Add(bagPic);
            //}
            //SLTDbContext.SaveChanges();
            return newBag;
        }

        public List<Color> GetColors()
        {
            return SLTDbContext.Colors.ToList();
        }

        public Bag GetBagById(int? id)
        {
            List<Color> listColors = new List<Color>();
            listColors = GetColors();
            Bag bag = SLTDbContext.Bags.Include(b => b.BagsColors).Include(b=> b.BagsPictures).
                Where(b => b.BagId == id).FirstOrDefault();            

            foreach (var item in listColors)
            {
                foreach (var colorItem in bag.BagsColors)
                {
                    
                    if (item.Id == colorItem.ColorId)
                    {

                        item.isChecked = true;
                    }
                    

                }
            }
            bag.ColorList = listColors;
            return bag;
        }

        public void UpdateBag(Bag uptBag)
        {
            Bag bag = SLTDbContext.Bags.Include(b => b.BagsColors).
                Where(b => b.BagId == uptBag.BagId).FirstOrDefault();
            if (bag != null)
            {
                foreach (var colorItem in bag.BagsColors.ToList())
                {
                    SLTDbContext.BagsColors.Remove(colorItem);
                }
                bag.BagBrand = uptBag.BagBrand;
                bag.Cost = uptBag.Cost;
                bag.sellCost = uptBag.sellCost;
                bag.Quantity = uptBag.Quantity;
                bag.CategoryId = uptBag.CategoryId;
                foreach (var item in uptBag.ColorList)
                {
                    if (item.isChecked == true)
                    {
                        BagsColors bc = new BagsColors();
                        bc.BagId = uptBag.BagId;
                        bc.ColorId = item.Id;
                        SLTDbContext.BagsColors.Add(bc);
                    }
                }
                SLTDbContext.Entry(bag).State = EntityState.Modified;
                SLTDbContext.SaveChanges();
            }
        }
    }
}