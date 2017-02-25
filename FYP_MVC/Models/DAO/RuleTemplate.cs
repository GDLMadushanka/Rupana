using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FYP_MVC.Models.DAO
{
    public class RuleTemplate
    {
        public int id;
        public string name;
        public int numOfDim;
        public string intention;

        public bool dim1_IsContinuous;
        public string dim1_Cardinality;
        public string dim1_context;

        public bool dim2_IsContinuous;
        public string dim2_Cardinality;
        public string dim2_context;

        public bool dim3_IsContinuous;
        public string dim3_Cardinality;
        public string dim3_context;

        public bool dim4_IsContinuous;
        public string dim4_Cardinality;
        public string dim4_context;

        public bool dim5_IsContinuous;
        public string dim5_Cardinality;
        public string dim5_context;

        public string recommendation;
        public string score;
    }
    public enum Intention
    {
        Comparison,
        Composition,
        Distribution,
        Relationship
    }
    public enum Cardinality
    {
        High,
        Low,
        Medium,
        Any
    }
    public enum Context
    {
        Numerical,
        TimeSeries,
        Percentage,
        Nominal
    }
}