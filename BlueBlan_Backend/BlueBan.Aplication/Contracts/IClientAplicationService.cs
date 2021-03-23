using BlueBan.Aplication.Entitydto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlueBan.Aplication.Contracts
{
    public interface IClientAplicationService
    {
        public Task<List<Clientdto>> getAllClients();
        public Task<Clientdto> getClientById(int id);
        public Task saveClient(Clientdto client);
        public Task updateClient(Clientdto client);
        public Task deleteClient(int id);
    }
}
