using AutoMapper;
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
            var isdeleted= await _accountDomineService.deleteAccount(_account);
            if (isdeleted) 
            {
                _logger.LogInformation($"Delete Account {account.ToString()}");
            }

            return isdeleted;
        }

        public async Task<Accountdto> getAccountByAccountNumber(string AccountNumbre)
        {
            var account= await _accountDomineService.getAccountByAccountNumber(AccountNumbre);

            var accountdto = _mapper.Map<Accountdto>(account);

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
            var isvave = await _accountDomineService.saveAccount(_account);

            if (isvave)
            {
                _logger.LogInformation($"Account created {account.ToString()}");
            }

            return isvave;
        }

        public async Task<bool> updateAccount(Accountdto account)
        {
            var _account = _mapper.Map<Account>(account);
            var isupdated= await _accountDomineService.updateAccount(_account);
            if (isupdated)
            {
                _logger.LogInformation($"Updated account {account.ToString()}");
            }
            return isupdated;
        }

        public async Task<bool> existsAccount(string AccountNumbre)
        {
            return await _accountDomineService.existsAccount(AccountNumbre);
        }

        public async Task<List<AccountMovedto>> getAccountMoveByAccountNumber(Guid Id, string AccountNumber)
        {
            var accountMove = await _accountDomineService.getAccountMoveByAccountNumber(Id,AccountNumber);

            var accountMovedto = _mapper.Map<List<AccountMovedto>>(accountMove);
            return accountMovedto;
        }

        public async Task<bool> creatMoveAccount(string AccountNumber, AccountMovedto accountMove)
        {
            var _accountMove = _mapper.Map<AccountMove>(accountMove);

            var iscreatedMove = await _accountDomineService.creatMoveAccount(AccountNumber, _accountMove);

            if (iscreatedMove) 
            {

                _logger.LogInformation($"movement created { _accountMove.ToString()}");
            }
            return iscreatedMove;
        }
    }
}
