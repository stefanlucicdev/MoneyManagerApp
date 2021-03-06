using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API.Entities
{
    public class AccountTransaction
    {
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [JsonIgnore]
        public MoneyAccount BaseMoneyAccount { get; set; }
        public int BaseMoneyAccountId { get; set; }
        public int TransactionValue { get; set; }
        public DateTime DateAdded { get; set; }
        public string Category { get; set; } = "test";
        public string Note { get; set; }
        public bool isIncome { get; set; } = false;
        public bool isRecurring { get; set; } = false;
    }
}
