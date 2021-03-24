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
        public async Task<bool> deleteAccount(Account account)
        {
            var _account = await getAccountById(account.AccountId);
            _blueBankContext.Remove(_account);

            return await save();
        }

        public async Task<Account> getAccountById(Guid id)
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



        public async Task<bool> saveAccount(Account account)
        {
            await _blueBankContext.Accounts.AddAsync(account);

            return await save();

        }

        public async Task<bool> updateAccount(Account account)
        {

              _blueBankContext.Update(account);

              return await save();
        }

        public async Task<bool> save()
        {
            var save = 0;
            var retorno = false;
            try
            {
                save = await _blueBankContext.SaveChangesAsync();
                retorno= save >= 0;

            }
            catch (Exception ex)
            {

                throw ex;
            }

            return retorno;
        }

        public async Task<bool> existsAccount(string AccountNumbre)
        {
            var exists = await Task.Factory.StartNew(() =>
            {
                return _blueBankContext.Accounts.Any(x => x.Number == AccountNumbre);
            });

            return exists;
        }

        public async Task<Account> getAccountByAccountNumber(string AccountNumbre)
        {
            var account = await Task.Factory.StartNew(() =>
            {
                return _blueBankContext.Accounts.FirstOrDefault(x => x.Number == AccountNumbre);
            });
            return account;
        }
    }
}
