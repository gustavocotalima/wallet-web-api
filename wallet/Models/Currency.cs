namespace wallet.Models
{
    public abstract class Currency
    {
        public decimal Amount { get; set; }

        public abstract decimal ToDollar();
        public abstract decimal ToEuro();
    }
    
    public class Dollar : Currency
    {
        public override decimal ToDollar()
        {
            return Amount;
        }

        public override decimal ToEuro()
        {
            return Amount * 0.85m; // Conversion rate as of the time of writing
        }
    }
    
    public class Euro : Currency
    {
        public override decimal ToDollar()
        {
            return Amount * 1.18m; // Conversion rate as of the time of writing
        }

        public override decimal ToEuro()
        {
            return Amount;
        }
    }
}