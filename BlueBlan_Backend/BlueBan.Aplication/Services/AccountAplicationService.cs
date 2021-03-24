﻿using AutoMapper;
using BlueBan.Aplication.Contracts;
using BlueBan.Aplication.Entitydto;
using BlueBlan.Dominio.Entity;
using BlueBlan.Dominio.Services;
using Microsoft.Extensions.Logging;
using NLog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlueBan.Aplication.Services
{
    public class AccountAplicationService : IAccountAplicationService
    {
        private readonly IAccountDomineService _accountDomineService;
        private readonly IMapper _mapper;
        private readonly ILogger<AccountAplicationService> _logger;

        public AccountAplicationService(IAccountDomineService _accountDomineService, IMapper _mapper, ILogger<AccountAplicationService> _logger)
        {
            this._accountDomineService = _accountDomineService;
            this._mapper = _mapper;
            this._logger = _logger;
        }
        public async Task<bool> deleteAccount(Accountdto account)
        {
            var _account = _mapper.Map<Account>(account);
            _logger.LogInformation($"Delete Account {account.Number}");
            return await _accountDomineService.deleteAccount(_account);
        }

        public async Task<Accountdto> getAccountByAccountNumber(string AccountNumbre)
        {
            var account= await _accountDomineService.getAccountByAccountNumber(AccountNumbre);

            var accountdto = _mapper.Map<Accountdto>(account);
            _logger.LogInformation($"Find Account {account.Number}");
            return accountdto;
        }

        public async Task<List<Accountdto>> getAllAccounts()
        {
            var accounts = await _accountDomineService.getAllAccounts();

            var accountsdto = _mapper.Map<List<Accountdto>>(accounts);

            return accountsdto;
        }

        public async Task<bool> saveAccount(Accountdto account)
        {
            var _account = _mapper.Map<Account>(account);
            _logger.LogInformation($"Save Account {account.Number}");
            return await _accountDomineService.saveAccount(_account);
        }

        public async Task<bool> updateAccount(Accountdto account)
        {
            var _account = _mapper.Map<Account>(account);
            _logger.LogInformation($"Update Account {account.Number}");
            return await _accountDomineService.updateAccount(_account);
        }

        public async Task<bool> existsAccount(string AccountNumbre)
        {
            return await _accountDomineService.existsAccount(AccountNumbre);
        }

    }
}
