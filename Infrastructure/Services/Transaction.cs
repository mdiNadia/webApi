using Application.Dtos.Transaction;
using Application.Errors;
using Application.Interfaces;
using Infrastructure.Identity;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class Transaction : GenericRepository<Domain.Entities.Transaction>, ITransaction
    {
        private readonly IUserAccessor _userAccessor;

        public Transaction(DataContext context, IConfiguration configuration, IUserAccessor userAccessor) : base(context, configuration)
        {
            this._userAccessor = userAccessor;
        }

        public async Task<int> AddTransaction(RequestInsertTransactionDto request)
        {
            var user = await _userAccessor.GetCurrentUserAsync();

            try
            {
                var model = new Domain.Entities.Transaction();
                model.Price = request.Price;
                model.UserId =user.Id ;
                model.TransactionDate = DateTime.Now;

                Insert(model);
                await SaveEntityChangeAsync();
                return 200;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<GetUsersDailyTransactionsReportDto>> UsersDailyTransactionsReportAsync()
        {
            var users = await _userAccessor.GetQueryList().ToListAsync();
            var data = await GetQueryList().ToListAsync();
            //if(data == null)
            //نحوه استفاده از هندلینگ خطاها با استفاده از میدلور
            //    throw new RestException(System.Net.HttpStatusCode.NotFound, new { Transaction = "Not Found" });
            var transactions = new List<GetUsersDailyTransactionsReportDto>();
            foreach (var item in data)
            {
               transactions.Add(new GetUsersDailyTransactionsReportDto() { UserFullName =item.User.FirstName+" "+item.User.LastName , UserId = item.UserId, Date = item.TransactionDate, Price = item.Price, Total = data.Where(c=>(c.TransactionDate.Year == item.TransactionDate.Year && c.TransactionDate.Month == item.TransactionDate.Month && c.TransactionDate.Day == item.TransactionDate.Day) && c.UserId == item.UserId).Select(c=>c.Price).Sum() });
            }
            return transactions;
        }
    }
}
