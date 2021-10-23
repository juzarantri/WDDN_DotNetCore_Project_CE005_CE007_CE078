using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PortfolioTracker.Models.Portfoliomodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PortfolioTracker.Models;

namespace PortfolioTracker.Models
{
    public class AppDbContext : IdentityDbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
        {
        }
        public DbSet<UsersRegister> UserDetails { get; set; }
        public DbSet<Coin> CoinDetails { get; set; }
        //public DbSet<PortfolioTracker.Models.UsersLogin> UsersLogin { get; set; }
    }
}
