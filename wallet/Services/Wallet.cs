using wallet.Models;

namespace wallet.Services
{
    public class Wallet<T> where T : Currency, new()
    {
        private List<T> currencies = new List<T>();

        public void AddFunds(decimal amount)
        {
            var currency = new T { Amount = amount };
            currencies.Add(currency);
        }

        public decimal GetBalanceInDollar()
        {
            return currencies.Sum(c => c.ToDollar());
        }

        public decimal GetBalanceInEuro()
        {
            return currencies.Sum(c => c.ToEuro());
        }

        public void ExchangeFunds(decimal amount, Func<decimal, decimal> exchangeRate)
        {
            var currency = currencies.FirstOrDefault(c => c.Amount >= amount);
            if (currency != null)
            {
                currency.Amount -= amount;
                var exchangedAmount = exchangeRate(amount);
                currencies.Add(new T { Amount = exchangedAmount });
            }
        }
    }
}