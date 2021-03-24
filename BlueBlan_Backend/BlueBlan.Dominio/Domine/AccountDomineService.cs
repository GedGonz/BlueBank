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
        public AccountDomineService(IAccountRepository _accountRepository)
        {
            this._accountRepository = _accountRepository;
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
            return await _accountRepository.saveAccount(account);
        }

        public async Task<bool> updateAccount(Account account)
        {
            return await _accountRepository.updateAccount(account);
        }

        public async Task<bool> existsAccount(string AccountNumbre)
        {
            return await _accountRepository.existsAccount(AccountNumbre);
        }


    }
}
