using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Transaction
{
    public class GetUsersDailyTransactionsReportDto
    {
        public string UserId { get; set; }
        public string UserFullName { get; set; }
        public DateTime Date { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
    }
}
