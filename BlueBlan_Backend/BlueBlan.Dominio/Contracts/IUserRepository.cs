using BlueBlan.Dominio.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlueBlan.Dominio.Contracts
{
    public interface IUserRepository
    {
        public Task<User> findUser(string userName,string password);
        public Task<User> findByNameUser(string userName);
        public Task<bool> existsUser(string userName);
    }
}
