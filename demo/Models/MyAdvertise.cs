using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace demo.Models
{
    public class MyAdvertise
    {
        public int advertiseId { get; set; }
        //public int productCategoryName { get; set; }
        public string advertiseTitle { get; set; }
        public string advertiseDescription { get; set; }
        public decimal advertisePrice { get; set; }
        //public int areaName { get; set; }
        public bool advertiseStatus { get; set; }
       // public string firstName { get; set; }
       // public bool advertiseApproved { get; set; }
           
    }
}