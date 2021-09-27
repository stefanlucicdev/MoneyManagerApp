using API.DTOs;
using API.Entities;
using API.Extensions;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class MoneyAccountController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public MoneyAccountController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost("add-transaction")]
        public async Task<ActionResult> AddTransaction(AccountTransactionDto accountTransactionDto)
        {
            var user = await _unitOfWork.UserRepository.GetUserByUsernameAsync(User.GetUsername());

            if (user != null)
            {
                var accountTransaction = new AccountTransaction()
                {
                    BaseMoneyAccountId = accountTransactionDto.BaseMoneyAccountId,
                    TransactionValue = accountTransactionDto.TransactionValue,
                    DateAdded = accountTransactionDto.DateAdded,
                    Note = accountTransactionDto.Note,
                };

                _unitOfWork.MoneyAccountRepository.AddTransaction(accountTransaction);

                if (await _unitOfWork.Complete()) return Ok();
            }

            return BadRequest("Failed to add a money account");
        }

        [HttpGet("transactions/{id}")]
        public async Task<ActionResult<IEnumerable<AccountTransaction>>> GetTransactionsAsync(int id)
        {
            var user = await _unitOfWork.UserRepository.GetUserByUsernameAsync(User.GetUsername());
            var moneyAccount = await _unitOfWork.UserRepository.GetMoneyAccountByIdAsync(id);
            
            if (user == moneyAccount.Owner) { 

            var transactions = await _unitOfWork.MoneyAccountRepository.GetTransactions(id);
            return Ok(transactions);

            }

            return BadRequest("You do not have access to this information.");
        }
    }
}
