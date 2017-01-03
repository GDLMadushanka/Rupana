using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FYP_MVC.Models.DAO;

namespace FYP_MVC.Core.RuleBaseComponent
{
    public class RuleBase
    {
        private static FYPEntities db = new FYPEntities();

        public static List<Recommendation_Result> getRecommendations_RuleBaseOnly(int tableID,string intention) {
          return   db.getRecommendationFromRules(tableID,intention).ToList<Recommendation_Result>();
            

        }
    }
}