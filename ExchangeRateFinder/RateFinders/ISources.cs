namespace ExchangeRateFinder.RateFinders
{
    public interface ISources
    {
        void CallAPI();

        void GetOutputCurrency();        
    }
}
