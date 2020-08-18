using SLT.DAL;
using SLT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SLT.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        SLTRepository repo = new SLTRepository();
        public ActionResult Index()
        {
            return View(repo.GetBagsColors());
         


            //UserDetails = db.Products.Where(o => lstProductIds.Contains(o.ProductID.ToString()))
            //    .SelectMany(o => o.Users.Select(u => new { o, u }))
            //    .Select(s => new UserProduct
            //    {
            //        ProductId = s.o.ProductId.ToString(),
            //        UserId = s.u.UserId.ToString()
            //    }).ToList();




        }
    }
}