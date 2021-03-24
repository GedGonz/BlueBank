using BlueBlan.Dominio.Contracts;
using BlueBlan.Dominio.Entity;
using BlueBlan.Dominio.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBlan.Dominio.Domine
{
    public class AccountDomineService : IAccountDomineService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IAccountMoveRepository _accountMoveRepository;
        public AccountDomineService(IAccountRepository _accountRepository, IAccountMoveRepository _accountMoveRepository)
        {
            this._accountRepository = _accountRepository;
            this._accountMoveRepository = _accountMoveRepository;
        }
        public async Task<bool> deleteAccount(Account account)
        {
            return await _accountRepository.deleteAccount(account);
        }

        public async Task<Account> getAccountByAccountNumber(string AccountNumbre)
        {
            return await _accountRepository.getAccountByAccountNumber(AccountNumbre);
        }

        public async Task<List<Account>> getAllAccounts()
        {
            var ListAll= await _accountRepository.getAllAccounts();

            return ListAll.ToList();
        }

        public async Task<bool> saveAccount(Account account)
        {
            account.Valuecurrent = account.ValueInit;

            return await _accountRepository.saveAccount(account);
        }

        public async Task<bool> updateAccount(Account account)
        {
            var _account = await _accountRepository.getAccountById(account.AccountId);

            account.ValueInit = _account.ValueInit;

            return await _accountRepository.updateAccount(account);
        }

        public async Task<bool> existsAccount(string AccountNumbre)
        {
            return await _accountRepository.existsAccount(AccountNumbre);
        }

        public async Task<List<AccountMove>> getAccountMoveByAccountNumber(Guid Id, string AccountNumber)
        {
            var listaAccountMove= await _accountMoveRepository.getAccountByAccountMoveNumber(Id,AccountNumber);

            return listaAccountMove.ToList();
        }

        public async Task<bool> creatMoveAccount(string AccountNumber,AccountMove accountMove)
        {
            var account = await _accountRepository.getAccountByAccountNumber(AccountNumber);

            //Verify the type move

            if (accountMove.TypeMove == ACOUNTMOVE_TYPE.CONSIGN)
            {
                account.Valuecurrent = account.Valuecurrent + accountMove.Value;
            }
            else if (accountMove.TypeMove == ACOUNTMOVE_TYPE.WITHDRAW)
            {
                account.Valuecurrent = account.Valuecurrent - accountMove.Value;
            }

            accountMove.AccountId = account.AccountId;

            await _accountRepository.updateAccount(account);

            return await _accountMoveRepository.saveAccountMove(accountMove);
        }

   
    }
}
