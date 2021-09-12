using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            var owner = await _unitOfWork.UserRepository.GetUserByIdAsync(moneyAccountDto.OwnerId);

            var moneyAccount = new MoneyAccount()
            {
                Owner = owner,
                Name = moneyAccountDto.Name,
                ExcludeFromTotal = moneyAccountDto.ExcludeFromTotal,
                Currency = moneyAccountDto.Currency,
                InitialBalance = moneyAccountDto.InitialBalance
            };

            _unitOfWork.UserRepository.AddMoneyAccount(moneyAccount);

            if (await _unitOfWork.Complete()) return Ok();

            return BadRequest("Failed to add a money account");
        }
    }
}
