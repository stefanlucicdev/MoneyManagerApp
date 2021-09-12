using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;

namespace API.Entities
{
    public class MoneyAccount
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public AppUser Owner { get; set; }
        public bool ExcludeFromTotal { get; set; }
        public string Currency { get; set; }
        public int InitialBalance { get; set; }
        public int CurrentBalance { get; set; }
        public int MonthlyCashFlow { get; set; }
        public int YearlyCashFlow { get; set; }
        public ICollection<AccountTransaction> Transactions { get; set; }
    }
}