using API.Data;
using API.DTOs;
using API.Entities;
using API.Extensions;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;


namespace API.Controllers
{
    public class UsersController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UsersController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost("add-account")]
        public async Task<ActionResult> AddMoneyAccount(MoneyAccountDto moneyAccountDto)
        {
            var user = await _unitOfWork.UserRepository.GetUserByUsernameAsync(User.GetUsername());

            if (user != null) { 

            var moneyAccount = new MoneyAccount()
            {
                Owner = user,
                OwnerId = user.Id,
                Name = moneyAccountDto.Name,
                ExcludeFromTotal = moneyAccountDto.ExcludeFromTotal,
                Currency = moneyAccountDto.Currency,
                InitialBalance = moneyAccountDto.InitialBalance,
                CurrentBalance = moneyAccountDto.InitialBalance
            };

            _unitOfWork.UserRepository.AddMoneyAccount(moneyAccount);

            if (await _unitOfWork.Complete()) return Ok();
            }

            return BadRequest("Failed to add a money account");
        }

        [HttpGet("accounts")]
        public async Task<ActionResult<IEnumerable<MoneyAccount>>> GetMoneyAccounts()
        {
            var user = await _unitOfWork.UserRepository.GetUserByUsernameAsync(User.GetUsername());

            if (user != null) {

            var moneyAccounts = await _unitOfWork.UserRepository.GetMoneyAccountsAsync(user.Id);

            return Ok(moneyAccounts);
            
            }

            return BadRequest("Failed to get money accounts");
        }
    }
}