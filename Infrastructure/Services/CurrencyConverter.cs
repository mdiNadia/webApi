using Application.Interfaces;
using Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class CurrencyConverter : ICurrencyConverter
    {
        public CurrencyConverter(DataContext context, IConfiguration configuration) : base()
        {
        }

        public double Convert(string fromCurrency, string toCurrency, double amount)
        {

            return 12;
        }
    }
}
