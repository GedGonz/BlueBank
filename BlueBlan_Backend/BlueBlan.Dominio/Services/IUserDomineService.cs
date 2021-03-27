using BlueBlan.Dominio.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlueBlan.Dominio.Services
{
    public interface IUserDomineService
    {
        public Task<User> findUser(string userName);
        public Task<bool> Authenticate(string username, string password);
    }
}
