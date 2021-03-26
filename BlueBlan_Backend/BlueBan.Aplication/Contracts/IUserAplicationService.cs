using BlueBan.Aplication.Entitydto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlueBan.Aplication.Contracts
{
    public interface IUserAplicationService
    {
        public Task<Userdto> findUser(string userName);
        public Task<bool> existsUser(string userName);
        public Task<bool> Authenticate(string username, string password);
    }
}
