using System;
using System.Windows.Forms;

namespace ExchangeRateFinder.RateFinders
{
    public class Context : IContext
    {
        private ISources Sources;

        public Context(ISources sources)
        {
            this.Sources = sources;
        }

        public void GetResults()
        {
            Sources.CallAPI();
            Sources.GetOutputCurrency();
        }

        public decimal GetResult()
        {
            Globals.results.Sort();
            return Globals.results[0];
        }

        public void PrintInConsole()
        {
            Console.WriteLine($"1 {Globals.basecurrency} = {GetResult()} {Globals.outputCurrency}");
            Console.ReadKey();
        }

        public void PrintInMessageBox()
        {
            MessageBox.Show($"1 {Globals.basecurrency} = {GetResult()} {Globals.outputCurrency}");
        }
    }
}
