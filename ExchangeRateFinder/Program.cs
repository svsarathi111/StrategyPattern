using System;
using ExchangeRateFinder.RateFinders;

namespace ExchangeRateFinder
{
    class Program
    {        
        static void Main(string[] args)
        {
            try
            {
                Globals.GetConfigData();

                Context source1 = new Context(new ApiLayer());                
                Context source2 = new Context(new OpenExchange());
                source1.GetResults();
                source2.GetResults();

                if (Globals.printMode == "console")
                {
                    source1.PrintInConsole();
                }
                else
                {
                    source1.PrintInMessageBox();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"An error occurred\nError Message: {ex.Message}\n{ex.StackTrace}");
                Console.ReadKey();
            }
        }        
    }
}
