using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioTracker.Models.Portfoliomodel
{
    public class Coin
    {
        public int id { get; set; }
        [Required]
        [Display(Name = "Coin type")]
        public string coin { get; set; }
        [Required]
        [Display(Name = "Quantity")]
        public double qyantity { get; set; }
        [Required]
        [Display(Name = "Buying price")]
        public double buyingprice { get; set; }
        public double totalinvested { get; set; }
        public string userid { get; set; }
    }
}
