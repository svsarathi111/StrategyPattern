using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRateFinder.RateFinders
{
    public interface IContext
    {
        decimal GetResult();

        void PrintInConsole();

        void PrintInMessageBox();
    }
}
