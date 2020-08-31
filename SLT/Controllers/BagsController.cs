using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SLT;
using SLT.Models;
using SLT.DAL;
using System.IO;
using System.Diagnostics;
using SLT.DTO;
using System.Data.Entity.Migrations;
using SLT.Interface;

namespace SLT.Controllers
{
    public class BagsController : Controller
    {
      

        private IBagRepository bagRepo;

        public BagsController()
        {
            this.bagRepo= new BagReporsitory(new SLTDbContext());
        }
       
    
        // GET: Bags
        public ActionResult Index()
        {
            var data = bagRepo.GetGroupedBags();                                                
                 
            return View(data);
        }

        // GET: Bags/Details/5
        public ActionResult Details(int? id)
        {
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bag bag = bagRepo.GetBagById(id);
        
            if (bag == null)
            {
                return HttpNotFound();
            }
            
            return View(bag);
        }

        // GET: Bags/Create
        public ActionResult Create()
        {
            Bag bag = new Bag();            
        
           bag.CategoryList = bagRepo.GetCategories();
            
           
            bag.ColorList = bagRepo.GetColors().ToList();
            return View(bag);
        }

        // POST: Bags/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Bag bag)
        {
            if (ModelState.IsValid)
            {
                List<Picture> BagsPictures = new List<Picture>();
                if (bag.files.Length > 0)
                {
                    foreach (HttpPostedFileBase file in bag.files)
                    {
                        if (file != null)
                        {
                            BagsPictures.Add(FileUpload(file));
                        }
                    }
                    bag.BagsPictures = BagsPictures;
                }
                bagRepo.AddBag(bag);
                return RedirectToAction("Index");
            }

            return View(bag);
        }
        [HttpPost]
        public Picture FileUpload(HttpPostedFileBase files)
        {
            int i = 1;
            Picture Fd = new Picture();
            String FileExt = Path.GetExtension(files.FileName).ToUpper();

            if (FileExt == ".PNG" || FileExt == ".JPG"|| FileExt == ".JPEG")
            {
                Stream str = files.InputStream;
                BinaryReader Br = new BinaryReader(str);
                Byte[] FileDet = Br.ReadBytes((Int32)str.Length);

               
                Fd.FileName = files.FileName;
                Fd.FileContent = FileDet;
                Fd.Order = i;
                i++;

                
            }
            else
            {

                ViewBag.FileStatus = "Invalid file format.";


            }
            return Fd;

        }
       

        // GET: Bags/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bag bag = bagRepo.GetBagById(id);
            List<SelectListItem> selectListItems = bagRepo.GetCategories().ToList();
            selectListItems.Find(c => c.Value == bag.CategoryId.ToString()).Selected = true;
            bag.CategoryList = selectListItems;
            if (bag == null)
            {
                return HttpNotFound();
            }
            return View(bag);
        }

        // POST: Bags/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Bag bag)
        {
            if (ModelState.IsValid)
            {
                List<Picture> BagsPictures = new List<Picture>();
                if (bag.files.Length > 0)
                {
                    foreach (HttpPostedFileBase file in bag.files)
                    {
                        if (file != null)
                        {                           
                     
                            BagsPictures.Add(FileUpload(file));
                        }
                    }
                    bag.BagsPictures = BagsPictures;
                }
                bagRepo.UpdateBag(bag);             
                return RedirectToAction("Index");
            }
            return View(bag);
        }

        // GET: Bags/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bag bag = bagRepo.Delete(id);
            if (bag == null)
            {
                return HttpNotFound();
            }
            return View(bag);
        }

        // POST: Bags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            bagRepo.DeleteConfirmed(id);
            bagRepo.Save();
            return RedirectToAction("Index");
        }

        public JsonResult DeletePic (int id)
        {

            return Json(bagRepo.DeletePic(id), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdatePic(List<Picture> pictures)
        {

        foreach(var item in pictures)
            {
                bagRepo.UpdatePic(item);
                bagRepo.Save();
            }
           
            return Json(new
            {
                resut = "OK"
            });

        }
     
    }
}
