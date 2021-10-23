using Binance.Net;
using Binance.Net.Objects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PortfolioTracker.Models;
using PortfolioTracker.Models.Portfoliomodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioTracker.Controllers
{
    public class CoinController : Controller
    {
        public static string coinName;
        private readonly ICoin coinRepo;
        public static int t = -1;
        public string[] coins = new string[] { "BTCUSDT", "BNBUSDT", "ETHUSDT", "ADAUSDT", "XRPUSDT", "SOLUSDT", "DOTUSDT", "DOGEUSDT", "AVAXUSDT", "VETUSDT" };
        public CoinController(ICoin _coinRepo)
        {
            this.coinRepo = _coinRepo;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            if (TempData["flag"] == null && t == -1){
                TempData["ReturnUrl"] = "/coin/index";
                return RedirectToAction("login", "account");
            }
            t = 1;
            IEnumerable<Coin> coinlist = coinRepo.getAllCoin();
            ViewBag.list = coinlist;
            coinName = HttpContext.Request.Query["returnUrl"].ToString();

            /// set current price for coins
            for(int i = 0; i < 10; i++)
            {
                string coin = coins[i];
                //CurrentPrice.Text = callResult.Data.Price.ToString();
                ViewData[coin] = await GetCoinPrice(coin);
            }

            if (coinName != "")
            {
                ViewBag.price = await GetCoinPrice(coinName);
                ViewBag.coin = coinName;
            }
            return View();
        }

        [HttpPost]
        public  IActionResult StoreCoin(Coin coindetails) {
            coinRepo.addCoin(coindetails);
            return RedirectToAction("Index", "Coin");
        }

        public static async Task<float> GetCoinPrice(string temp)
        {
            var client = new BinanceClient(new BinanceClientOptions() { });
                var callResult = await client.Spot.Market.GetPriceAsync(temp);
                var price = float.Parse(callResult.Data.Price.ToString());
                return price;
            
        }

        public IActionResult deleteCoin(string id) {
            coinRepo.delete(Int32.Parse(id));
            return RedirectToAction("Index", "Coin");
        }

    }
}
