using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TechOneAssessment.Models
{
    public class IndexViewModel
    {
        public string Words { get; set; }
        [Required(ErrorMessage = "Please enter you number")]
        [Range(1, 1000000000000000, ErrorMessage ="Number is invalid")]
        public double Numbers { get; set; }
    }
}