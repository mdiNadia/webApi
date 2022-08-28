﻿using Application.Dtos.Transaction;
using Application.Errors;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PouyanSiteStore.Controllers
{
    public class TransactionController : BaseController
    {
        private readonly ILogger<TransactionController> _logger;

        private readonly ITransaction _transaction;

        public TransactionController(ILogger<TransactionController> logger, ITransaction transaction)
        {
            _logger = logger;
            this._transaction = transaction;
        }
        [HttpPost("AddTransaction")]
        public async Task<IActionResult> AddTransactionAsync([FromQuery] RequestInsertTransactionDto request)
        {
            var result = await _transaction.AddTransaction(request);
            return Ok(result);
        }

        [HttpGet("UsersDailyTransactionsReport")]
        public async Task<IActionResult> UsersDailyTransactionsReportAsync()
        {
            var result = await _transaction.UsersDailyTransactionsReportAsync();
            return Ok(result);
        }
    }
}
