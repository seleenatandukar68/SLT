using SLT.Interface;
using SLT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.ModelBinding;
using System.Data;

using System.IO;
using System.Threading.Tasks;
using System.Data.Entity;
using SLT.DTO;
using System.Collections;
using System.Web.Mvc;
using System.Data.Entity.Migrations;

namespace SLT.DAL
{
    public class BagReporsitory : IBagRepository, IDisposable
    {
       
        private SLTDbContext SLTDbContext;

        public BagReporsitory (SLTDbContext context)
        {
            this.SLTDbContext = context;
        }
       
        public IEnumerable<SelectListItem> GetCategories()
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
        public IEnumerable<Bag> GetBags()
        {

            return SLTDbContext.Bags.Include(b => b.BagsPictures);
              
             //(from b in SLTDbContext.Bags
             // join p in SLTDbContext.Pictures on b.BagId equals p.BagId
             // select b);
        }

        public Bag AddBag (Bag newBag)
        {
            
            SLTDbContext.Bags.Add(newBag);
            
           
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
           
            return newBag;
        }

        public IEnumerable<Color> GetColors()
        {
            return SLTDbContext.Colors.ToList();
        }

        public Bag GetBagById(int? id)
        {
            List<Color> listColors = new List<Color>();
            listColors = GetColors().ToList();
          
            var orderedBags =  GetSortedPic(id);
            Bag bag = new Bag();
            bag = orderedBags.Result;
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
        public async Task<Bag> GetSortedPic(int? id)
        {
            var parentBag = SLTDbContext.Bags
                .Include(b => b.BagsColors).Include(b => b.BagsPictures)
                .SingleOrDefaultAsync(b => b.BagId == id);

            parentBag.Result.BagsPictures = parentBag.Result.BagsPictures.OrderBy(c => c.Order).ToList();

            return await parentBag;
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
                SLTDbContext.Bags.AddOrUpdate(uptBag);
                foreach(var item in uptBag.BagsPictures)
                {
                    item.BagId = uptBag.BagId;

                    SLTDbContext.Pictures.Add(item);
                }
               
            
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
                
                //SLTDbContext.Entry(bag).State = EntityState.Modified;
                SLTDbContext.SaveChanges();
            }
        }

        public void UpdatePic (Picture uptPic)
        {
            Picture old = SLTDbContext.Pictures.Where(o => o.PicId == uptPic.PicId).FirstOrDefault();
            old.Order = uptPic.Order;
            SLTDbContext.Entry(old).State = EntityState.Modified;
        }
        public Bag Delete(int? id)
        {
            Bag bag = SLTDbContext.Bags.Find(id);
            return bag;
        }

        public void DeleteConfirmed(int? id)
        {
            Bag bag = SLTDbContext.Bags.Find(id);
            SLTDbContext.Bags.Remove(bag);
        }
        public string DeletePic (int id)
        {
            string message = "Pic Deleted";
            
           Picture pDel =  SLTDbContext.Pictures.Find(id);
            SLTDbContext.Pictures.Remove(pDel);
            SLTDbContext.SaveChanges();
            return message;
        }

        public IEnumerable<BagDTO> GetGroupedBags()
        {
            var data =
            (from b in SLTDbContext.Bags
             join p in SLTDbContext.Pictures on b.BagId equals p.BagId
             select new { b, p } into bs
             orderby bs.p.Order ascending
             group bs by bs.b.BagBrand into g

             select
                                       new BagDTO
                                       {
                                           BagBrand = g.Key,
                                           BagId = g.Select(gid => gid.b.BagId).FirstOrDefault(),
                                           FileContent = (Byte[])g.Select(gp => gp.p.FileContent)
                                           .FirstOrDefault()

                                       }).ToList();
            return data;
        }

        public void Save()
        {
            SLTDbContext.SaveChanges();
        }



        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    SLTDbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

       
    }
}