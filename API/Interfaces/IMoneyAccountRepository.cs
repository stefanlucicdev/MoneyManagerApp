using API.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace API.Interfaces
{
    public interface IMoneyAccountRepository
    {
        void AddTransaction(AccountTransaction transaction);
        Task<IEnumerable<AccountTransaction>> GetTransactions(int id);
    }
}
