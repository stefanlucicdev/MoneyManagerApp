using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace API.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public UserRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async void AddMoneyAccount(MoneyAccount moneyAccount)
        {
            await _context.MoneyAccounts.AddAsync(moneyAccount);
        }

        public async Task<AppUser> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<AppUser> GetUserByUsernameAsync(string username)
        {
            return await _context.Users.SingleOrDefaultAsync(x => x.UserName == username);
        }

        public void Update(AppUser user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }

        public async Task<IEnumerable<MoneyAccount>> GetMoneyAccountsAsync(int id)
        {
            return await _context.MoneyAccounts.Where(moneyAccount => moneyAccount.OwnerId == id).ToListAsync();               
        }

        public async Task<MoneyAccount> GetMoneyAccountByIdAsync(int id)
        {
            return await _context.MoneyAccounts.FindAsync(id);
        }
    }
}
