﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyProject.Model
{
    public class ProductInOutModel : Notifier
    {
        //PRODUCT
        public string Prod_code { get; set; }
        public string Prod_name { get; set; }
        public DateTime Prod_expire { get; set; }
        public int? Prod_price { get; set; }

        //CATEGORY
        public string Category_name { get; set; }

        //PRODUCT_IN
        public int? Prod_in_count { get; set; }
        public DateTime Prod_in_date { get; set; }

        //PRODUCT_OUT
        public int? Prod_out_count { get; set; }
        public DateTime Prod_out_date { get; set; }
        public string Prod_out_content { get; set; }

        //NURSE
        public string Nurse_name { get; set; }


    }//class

}//namespace
