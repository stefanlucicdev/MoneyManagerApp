using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace API.Data
{
    public class MoneyAccountRepository : IMoneyAccountRepository
    {
        private readonly DataContext _context;
        public MoneyAccountRepository(DataContext context)
        {
            _context = context;
        }
        public async void AddTransaction(AccountTransaction transaction)
        {
            await _context.Transactions.AddAsync(transaction);
        }
        public async Task<IEnumerable<AccountTransaction>> GetTransactions(int id)
        {
            return await _context.Transactions.Where(transaction => transaction.BaseMoneyAccountId == id).ToListAsync();
        }
    }
}
