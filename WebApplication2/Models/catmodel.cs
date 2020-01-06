using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using Dapper;

namespace WebApplication2.Models
{
    public class catmodel
    {
        [Required(ErrorMessage = "Name is required.")]
        public int category_id { get; set; }
        public string Name { get; set; }
        public Byte status { get; set; }
        public List<catmodel> getdata { get; set; }
    }

  
}