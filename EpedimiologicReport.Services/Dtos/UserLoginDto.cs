using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpedimiologicReport.Services.Dtos;

public class UserLoginDto
{
    [Required]
    [EmailAddress]
    public string Name { get; set; }
    [MinLength(5)]
    public string Password { get; set; }
}
