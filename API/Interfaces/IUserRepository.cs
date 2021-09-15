using API.DTOs;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Interfaces
{
    public interface IUserRepository
    {
        void Update(AppUser user);
        Task<AppUser> GetUserByIdAsync(int id);
        void AddMoneyAccount(MoneyAccount moneyAccount);
        Task<AppUser> GetUserByUsernameAsync(string username);
    }
}
