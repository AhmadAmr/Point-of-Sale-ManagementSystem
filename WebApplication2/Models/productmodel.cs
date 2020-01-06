using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Models
{
 
    public class productmodel
    {
        public int     category_id { get; set; }
        public string  category_name { get; set; }
        public string  product_name { get; set; }
        public double  price { get; set; }
        public int     capacity { get; set; }
        public int     store_id { get; set; }
        public string  store_name { get; set; }
        public Byte    status { get; set; }
        public SelectList Catlist { get; set; }
        public SelectList Storelist { get; set; }
    }
    public class catContext
    {
        
            SqlConnection con = new SqlConnection("Data Source =.; Initial Catalog = cms; Integrated Security = True; MultipleActiveResultSets=True");

            public IEnumerable<productmodel>GetMobileList()
            {
                string query = "SELECT category_id,category_name from category";
                var result = con.Query<productmodel>(query);
                return result;
            }
    }

    public class storeContext
    {

        SqlConnection con = new SqlConnection("Data Source =.; Initial Catalog = cms; Integrated Security = True; MultipleActiveResultSets=True");

        public IEnumerable<productmodel> GetstoreList()
        {
            string query = "SELECT store_id,store_name from store";
            var result = con.Query<productmodel>(query);
            return result;
        }
    }


}