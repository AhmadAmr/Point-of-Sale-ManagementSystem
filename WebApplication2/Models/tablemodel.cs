using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class tablemodel
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        public int  capacity { get; set; }
        public Byte status { get; set; }
        public List<tablemodel> getdata { get; set; }
    }
}