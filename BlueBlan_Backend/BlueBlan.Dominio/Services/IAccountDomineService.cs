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
        public Task<Account> getAccountByAccountNumber(Guid Clientid, string AccountNumbre);
        public Task<bool> saveAccount(Account account);
        public Task<bool> updateAccount(Account account);
        public Task<bool> deleteAccount(Account account);
        public Task<bool> existsAccount(string AccountNumbre);
        public Task<List<AccountMove>> getAccountMoveByAccountNumber(Guid Id,string AccountNumbre);
        public Task<bool> creatMoveAccount(string AccountNumber, AccountMove accountMove);


    }
}
