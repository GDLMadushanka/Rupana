using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FYP_MVC.Models.DAO;

namespace FYP_MVC.Core.Recommendation
{
    public class Recommendation
    {

        private static FYPEntities db = new FYPEntities();


        public static List<Recommendation_Result> getRecommendations(int tableID, string intention)
        {
            return db.getRecommendations(tableID, intention).ToList<Recommendation_Result>();


        }
        public static List<Recommendation_Result> getRecommendationsMore(int tableID, string intention)
        {
            return db.getRecommendations_More(tableID, intention).ToList<Recommendation_Result>();


        }
        public static List<Recommendation_Result> getRecommendationsWithoutIntention(int tableID, string intention)
        {
            return db.getRecommendations_WithoutIntention(tableID).ToList<Recommendation_Result>();


        }
        public static List<Recommendation_Result> getRecommendationsWithoutIntentionMore(int tableID, string intention)
        {
            return db.getRecommendations_More_WithoutIntention(tableID).ToList<Recommendation_Result>();


        }
    }
}