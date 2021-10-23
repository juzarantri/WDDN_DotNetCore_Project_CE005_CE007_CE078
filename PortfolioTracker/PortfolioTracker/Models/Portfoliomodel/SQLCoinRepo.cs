using PortfolioTracker.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PortfolioTracker.Models.Portfoliomodel
{
    public class SQLCoinRepo : ICoin
    {
        private readonly AppDbContext context;
        public SQLCoinRepo(AppDbContext context)
        {
            this.context = context;
        }
        public void addCoin(Coin c)
        {
            context.CoinDetails.Add(new Coin
            {
                coin = CoinController.coinName,
                qyantity = c.qyantity,
                buyingprice = c.buyingprice,
                totalinvested = (c.qyantity * c.buyingprice),
                userid = AccountController.id,
            }) ;
            context.SaveChanges();
        }

        public IEnumerable<Coin> getAllCoin()
        {
            return context.CoinDetails.Where(u => u.userid == AccountController.id);
        }

        public void delete(int id) {
            var delRow = context.CoinDetails.Single(a => a.id == id);
            context.Remove(delRow);
            context.SaveChanges();
        }
    }
}
