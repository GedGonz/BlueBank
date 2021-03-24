using BlueBan.Aplication.Entitydto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlueBan.Aplication.Contracts
{
    public interface IAccountAplicationService
    {
        public Task<List<Accountdto>> getAllAccounts();
        public Task<Accountdto> getAccountByAccountNumber(string AccountNumbre);
        public Task<bool> saveAccount(Accountdto account);
        public Task<bool> updateAccount(Accountdto account);
        public Task<bool> deleteAccount(Accountdto account);
        public Task<bool> existsAccount(string AccountNumbre);
    }
}
