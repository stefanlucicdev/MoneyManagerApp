using API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class AccountTransactionDto
    {
        public int TransactionValue { get; set; }
        public int BaseMoneyAccountId { get; set; }
        public DateTime DateAdded { get; set; }
        public string Note { get; set; } = "";
    }
}
