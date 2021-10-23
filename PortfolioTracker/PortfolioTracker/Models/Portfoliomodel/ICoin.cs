using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioTracker.Models.Portfoliomodel
{
    public interface ICoin
    {
        /*public void addCoin(Coin c,string s);*/
        public void addCoin(Coin c);
        public IEnumerable<Coin> getAllCoin();
        public void delete(int v);
    }
}
