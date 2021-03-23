using BlueBan.Aplication.Entitydto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlueBan.Aplication.Contracts
{
    public interface IAccountAplicationSercice
    {
        public Task<List<Accountdto>> getAllAccounts();
        public Task<Accountdto> getAccountById(int id);
        public Task saveAccount(Accountdto account);
        public Task updateAccount(Accountdto account);
        public Task deleteAccount(int id);
    }
}
