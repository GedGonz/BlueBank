using BlueBlan.Dominio.Contracts;
using BlueBlan.Dominio.Entity;
using BlueBlan.Dominio.Services;
using System;
using System.Collections.Generic;
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
        public async Task deleteAccount(int id)
        {
            await _accountRepository.deleteAccount(id);
        }

        public async Task<Account> getAccountById(int id)
        {
            return await _accountRepository.getAccountById(id);
        }

        public async Task<List<Account>> getAllAccounts()
        {
            var ListAll= await _accountRepository.getAllAccounts();

            return (List<Account>)ListAll;
        }

        public async Task saveAccount(Account account)
        {
            await _accountRepository.saveAccount(account);
        }

        public async Task updateAccount(Account account)
        {
            await _accountRepository.updateAccount(account);
        }
    }
}
