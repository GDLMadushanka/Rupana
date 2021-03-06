﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FYP_MVC.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        public ActionResult page1()
        {
            return View();
        }
        public ActionResult page2()
        {
            return View();
        }
        public ActionResult page3()
        {
            return View();
        }
        public ActionResult page4()
        {
            return View();
        }

        public ActionResult ChartDiscriptionPage()
        {
            ViewBag.path = "Chart descriptions";
            return View();
        }
        public ActionResult publications()
        {
            ViewBag.path = "Publications";
            return View();
        }
        public FileStreamResult getPublication1()
        {
            var pathToTheFile = Server.MapPath("~/Content/papers/context_aware_recommendation_for_data_visualization.pdf");
            var fileStream = new FileStream(pathToTheFile,
                                                FileMode.Open,
                                                FileAccess.Read
                                            );
            return File(fileStream, "application/pdf");
        }

        public ActionResult Guide()
        {
            ViewBag.path = "Guide";
            return View();
        }
        public ActionResult DevTeam()
        {
            ViewBag.path = "Development team";
            return View();
        }

    }
}