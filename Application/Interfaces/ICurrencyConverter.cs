using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
   public interface ICurrencyConverter
    {
        /// <summary>
        /// Converts the specified amount to the desired currency.
        /// </summary>
        double Convert(string fromCurrency, string toCurrency, double amount);
    }
}
