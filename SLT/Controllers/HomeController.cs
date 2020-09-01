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
            return View();     

        }
    }
}