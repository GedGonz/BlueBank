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
    public class AccountMoveRepository : IAccountMoveRepository
    {
        private BlueBankContext _blueBankContext;

        public AccountMoveRepository(BlueBankContext _blueBankContext)
        {
            this._blueBankContext = _blueBankContext;
        }

        public async Task<bool> existsAccountMove(string AccountNumber)
        {
            try
            {
                var exists = await Task.Factory.StartNew(() =>
                {
                    return (from x in _blueBankContext.Accounts
                            join y in _blueBankContext.AccountMoves on x.AccountId equals y.AccountId
                            where x.Number == AccountNumber
                            select x).Any();
                });

                return exists;
            }
            catch (Exception)
            {

                throw;
            }

           
        }

        public async Task<IQueryable<AccountMove>> getAccountByAccountMoveNumber(Guid Id,string AccountNumber)
        {
            try
            {
                var accountMove = await Task.Factory.StartNew(() =>
                {
                    return (from x in _blueBankContext.Accounts
                            join y in _blueBankContext.AccountMoves on x.AccountId equals y.AccountId
                            where x.ClientId == Id && x.Number == AccountNumber
                            select y);
                });
                return accountMove;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<AccountMove> getAccountMoveById(Guid id)
        {
            try
            {
                return await _blueBankContext.AccountMoves.FindAsync(id);
            }
            catch (Exception)
            {

                throw;
            }
            
        }


        public async Task<bool> save()
        {
            var save = 0;
            var retorno = false;
            try
            {
                save = await _blueBankContext.SaveChangesAsync();
                retorno = save >= 0;

            }
            catch (Exception ex)
            {

                throw ex;
            }

            return retorno;
        }

        public async Task<bool> saveAccountMove(AccountMove accountMove)
        {
            try
            {
                await _blueBankContext.AccountMoves.AddAsync(accountMove);

                return await save();
            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}
