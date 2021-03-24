using BlueBlan.Dominio.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBlan.Dominio.Contracts
{
    public interface IAccountMoveRepository
    {
        public Task<AccountMove> getAccountMoveById(Guid id);
        public Task<IQueryable<AccountMove>> getAccountByAccountMoveNumber(Guid Id, string AccountNumbre);
        public Task<bool> saveAccountMove(AccountMove accountMove);
        public Task<bool> existsAccountMove(string AccountNumber);
        public Task<bool> save();
    }
}
