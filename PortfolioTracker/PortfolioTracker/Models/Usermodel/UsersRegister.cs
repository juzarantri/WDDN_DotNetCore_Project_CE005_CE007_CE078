using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioTracker.Models
{
    public class UsersRegister
    {
        public int id { get; set; }

        [Required]
        [Display(Name = "Username")]
        public string username{ get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string password { get; set; }

        [Required]
        [Compare("password", ErrorMessage = "Password didn't matched")]
        [DataType(DataType.Password)]
        [Display(Name ="Confirm Password")]
        public string confirmpassword { get; set; }


    }
}
