using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class AppUser : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Currency { get; set; }
        public string Country { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public ICollection<MoneyAccount> MoneyAccounts { get; set; }
        public ICollection<AppUserRole> UserRoles { get; set; }
        public int MonthlyCashFlow { get; set; }
        public int YearlyCashFlow { get; set; }
        public int CurrentBalance { get; set; }
    }
}
