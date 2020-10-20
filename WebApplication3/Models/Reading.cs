using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class Reading
    {
        public int Id { get; set; }
        public string Scoure { get; set; }
        public string Reading1 { get; set; }
        public string Reading2 { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreateDate { get; set; }

    }
}