using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FYP_MVC.Controllers;
using System.Web.Mvc;
using FYP_MVC.Models.DAO;
using FYP_MVC.Models;

namespace FYP_MVC.Unit_Testing
{
    [TestClass]
    public class ControllerTest
    {
        [TestMethod]
        public void test_12344()
        {
            AdminController adminController = new AdminController();
            //result.
            user userk = new user
            {
                firstName = "sadf",
                lastName = "sssss",
                email = "aaaee",
                passwword = "sdgsa",
                userType = "asd"

            };
        
            ViewResult result = adminController.Index() as ViewResult;
            Assert.AreEqual("", result.ViewBag);
            //Assert.IsNotNull(result);

        }

        [TestMethod]
        public void test_HomeControllerAbout()
        {
            HomeController homeController = new HomeController();
            ViewResult result = homeController.About() as ViewResult;
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void test_HomeControllerContact()
        {
            HomeController homeController = new HomeController();
            ViewResult result = homeController.Contact() as ViewResult;
            Assert.AreEqual("Your contact page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void test_HomeControllerwelcomePage()
        {
            HomeController homeController = new HomeController();
            ViewResult result = homeController.welcomePage() as ViewResult;
            Assert.IsNotNull(result);
        }




        [TestMethod]
        public void test_TaskController_Home()
        {
            TaskController taskController = new TaskController();
            ActionResult result = taskController.Home() as ViewResult;
            Assert.IsNotNull(result);

        }
        [TestMethod]
        public void test_TaskController_UploadCSV()
        {
            TaskController taskController = new TaskController();
            ViewResult result = taskController.UploadCSV() as ViewResult;
            CSVFile csv = (CSVFile)result.Model;
            Assert.AreEqual(true, csv.hasHeader);

        }



        [TestMethod]
        public void test_AccountControllerLogin()
        {
            AccountController accountController = new AccountController();
            var result = accountController.Login("testing") as ViewResult;
            Assert.AreEqual("testing", result.ViewBag.ReturnUrl);
        }

        [TestMethod]
        public void test_AccountControllerResetPassword()
        {
            AccountController accountController = new AccountController();
            var result = accountController.ResetPassword("gttt") as ViewResult;
            Assert.AreEqual("", result.ViewName);

        }

        [TestMethod]
        public void test_AdminControllerIndex()
        {
            AdminController adminController = new AdminController();
            var result = adminController.Index() as ViewResult;

            Assert.AreEqual("Index", result.ViewData["activeMenu"]);
        }

        [TestMethod]
        public void test_AdminControllerHome()
        {
            AdminController adminController = new AdminController();
            var result = adminController.Home() as ViewResult;

            Assert.AreEqual("Home", result.ViewData["activeMenu"]);
        }

        [TestMethod]
        public void test_AdminControllerAddnewchart()
        {
            AdminController adminController = new AdminController();
            var result = adminController.AddNewChart() as ViewResult;

            Assert.AreEqual("AddNewChart", result.ViewData["activeMenu"]);
        }


    }
}