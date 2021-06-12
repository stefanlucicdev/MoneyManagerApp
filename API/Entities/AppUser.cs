using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class AppUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Currency { get; set; }
        public string Country { get; set; }
        public DateTime DateOfBirth { get; set; }
        public ICollection<MoneyAccount> Accounts { get; set; }
        public int MonthlyCashFlow { get; set; }
        public int YearlyCashFlow { get; set; }
        public int CurrentBalance { get; set; }
    }
}
