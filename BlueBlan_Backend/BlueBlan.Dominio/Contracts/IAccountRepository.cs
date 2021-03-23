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
        public Task<Account> getAccountById(int id);
        public Task saveAccount(Account account);
        public Task updateAccount(Account account);
        public Task deleteAccount(int id);
    }
}
