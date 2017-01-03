using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FYP_MVC.Models.DAO
{
    [MetadataType(typeof(Recommendation_ResultMetaData))]
    public partial class Recommendation_Result
    {

    }

    public class Recommendation_ResultMetaData
    {
        [Key]
        [Column(Order = 0)]
        public string chartName { get; set; }
        [Key]
        [Column(Order = 1)]
        public Nullable<int> tableDimIndex { get; set; }
        [Key]
        [Column(Order = 2)]
        public Nullable<int> chartDimIndex { get; set; }
    }
}