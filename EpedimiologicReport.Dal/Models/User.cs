using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpedimiologicReport.Dal.Models
{

    public class User
    {
       
        public int? ID { get; set; }
        [Required]
        [EmailAddress]
        public string? Name { get; set; }
        [MinLength(5)]
        public string? Password { get; set; }
    }
}
