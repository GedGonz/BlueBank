using BlueBlan.Dominio.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBlan.Dominio.Contracts
{
    public interface IAccountRepository
    {
        public Task<IQueryable<Account>> getAllAccounts();
        public Task<Account> getAccountById(Guid id);
        public Task<Account> getAccountByAccountNumber(string AccountNumbre);
        public Task<bool> saveAccount(Account account);
        public Task<bool> updateAccount(Account account);
        public Task<bool> deleteAccount(Account account);
        public Task<bool> existsAccount(string AccountNumber);
        public Task<bool> save();
    }
}
