using Microsoft.AspNetCore.Mvc;
using wallet.Models;
using wallet.Services;

namespace wallet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WalletController : ControllerBase
    {
        private Wallet<Dollar> wallet;

        public WalletController(Wallet<Dollar> wallet)
        {
            this.wallet = wallet;
        }

        [HttpPost("addfunds/{amount}")]
        public IActionResult AddFunds(decimal amount)
        {
            wallet.AddFunds(amount);
            return Ok();
        }

        [HttpGet("balance/dollar")]
        public IActionResult GetBalanceInDollar()
        {
            var balance = wallet.GetBalanceInDollar();
            return Ok(balance);
        }

        [HttpGet("balance/euro")]
        public IActionResult GetBalanceInEuro()
        {
            var balance = wallet.GetBalanceInEuro();
            return Ok(balance);
        }

        [HttpPost("exchange/{amount}")]
        public IActionResult ExchangeFunds(decimal amount, Func<decimal, decimal> exchangeRate)
        {
            wallet.ExchangeFunds(amount, exchangeRate);
            return Ok();
        }
    }
}