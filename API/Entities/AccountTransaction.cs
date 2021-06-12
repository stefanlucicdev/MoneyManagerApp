using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class AccountTransaction
    {
        public MoneyAccount AddedToAccount { get; set; }
        public int Id { get; set; }
        public int TransactionValue { get; set; }
        public DateTime DateAdded { get; set; }
        public string Category { get; set; }
        public string Note { get; set; }
        public bool isIncome { get; set; } = false;
    }
}
