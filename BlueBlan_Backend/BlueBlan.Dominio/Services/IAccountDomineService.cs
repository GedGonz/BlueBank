using BlueBlan.Dominio.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlueBlan.Dominio.Services
{
    public interface IAccountDomineService
    {
        public Task<List<Account>> getAllAccounts();
        public Task<Account> getAccountById(int id);
        public Task saveAccount(Account account);
        public Task updateAccount(Account account);
        public Task deleteAccount(int id);
    }
}
