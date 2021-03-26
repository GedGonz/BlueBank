using BlueBlan.Dominio.Contracts;
using BlueBlan.Dominio.Entity;
using BlueBlan.Infraestructura.Context;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlueBlan.Infraestructura.Repository
{
    public class UserRepository : IUserRepository
    {
        private BlueBankContext _blueBankContext;

        public UserRepository(BlueBankContext _blueBankContext)
        {
            this._blueBankContext = _blueBankContext;
        }
        public async Task<bool> existsUser(string userName)
        {
            try
            {
                var exists = await Task.Factory.StartNew(() =>
                {
                    return _blueBankContext.Users.Any(x => x.UserName == userName);
                });

                return exists;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<User> findByNameUser(string userName)
        {
            try
            {
                var user = await Task.Factory.StartNew(() =>
                {
                    return _blueBankContext.Users.FirstOrDefault(x => x.UserName == userName);
                });

                return user;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<User> findUser(string userName, string password)
        {
            try
            {
                var user = await Task.Factory.StartNew(() =>
                {
                    return _blueBankContext.Users.FirstOrDefault(x => x.UserName == userName && x.PasswordHash==password);
                });

                return user;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
