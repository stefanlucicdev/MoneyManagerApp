using API.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class MoneyAccountDto
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        [Required]
        public string Name { get; set; } = "New Account";
        public bool ExcludeFromTotal { get; set; } = false;
        public string Currency { get; set; } = "USD";
        public int InitialBalance { get; set; } = 0;
    }
}
