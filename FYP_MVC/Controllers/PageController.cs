using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FYP_MVC.Controllers
{
    public class PageController : Controller
    {
        // GET: Page
        public ActionResult Index()
        {
            ViewData["activeMenu"] = "Home";
            return View();
        }
        public ActionResult AboutUs()
        {
            ViewData["activeMenu"] = "AboutUs";
            return View();
        }
        public ActionResult Charts()
        {
            ViewData["activeMenu"] = "Charts";
            return View();
        }
        public ActionResult Guide()
        {
            ViewData["activeMenu"] = "Guide";
            return View();
        }
        public ActionResult Contact()
        {
            ViewData["activeMenu"] = "Contact";
            return View();
        }

    }
}