using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FYP_MVC.Core.RuleBaseComponent;
using FYP_MVC.Models.DAO;
using FYP_MVC.Core.Recommendation;

namespace FYP_MVC.Controllers
{
    public class ReccomendationController : Controller
    {
        // GET: Reccomendation
        public ActionResult Index()
        {

            int tableID = 1;
            string intention = "Comparison";

            List<Recommendation_Result> resultList= Recommendation.getRecommendations(tableID,intention);

            foreach (Recommendation_Result r in resultList) {
                Console.WriteLine(r.chartName + ' ' + r.tableDimIndex + ' ' + r.chartDimIndex);

                ViewBag.chartName = r.chartName;
            }

            return View(resultList);
        }

       
    }
}