using BlueBlan.Dominio.Contracts;
using BlueBlan.Dominio.Entity;
using BlueBlan.Infraestructura.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBlan.Infraestructura.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private BlueBankContext _blueBankContext;

        public AccountRepository(BlueBankContext _blueBankContext)
        {
            this._blueBankContext = _blueBankContext;
        }
        public async Task deleteAccount(int id)
        {
            var account = await getAccountById(id);
            if (account!=null) 
            {
                _blueBankContext.Remove(account);
                await _blueBankContext.SaveChangesAsync();
            }
        }

        public async Task<Account> getAccountById(int id)
        {
            return await _blueBankContext.Accounts.FindAsync(id);
        }

        public async Task<IQueryable<Account>> getAllAccounts()
        {
            var ListAllAccount = await Task.Factory.StartNew(() =>
            {
                return _blueBankContext.Accounts.AsQueryable();
            });

            return ListAllAccount;
        }

        public async Task saveAccount(Account account)
        {
            await _blueBankContext.Accounts.AddAsync(account);
            await _blueBankContext.SaveChangesAsync();
        }

        public async Task updateAccount(Account account)
        {
            var _account = await getAccountById(account.AccountId);
            if (_account != null)
            {
                _account.Number = account.Number;
                _account.Value = account.Value;
                _account.Type = account.Type;
                _account.ClientId = account.ClientId;

                _blueBankContext.Remove(_account);
                await _blueBankContext.SaveChangesAsync();
            }
        }
    }
}
