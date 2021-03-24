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
        public Task<bool> saveClient(Clientdto client);
        public Task<bool> updateClient(Clientdto client);
        public Task<bool> deleteClient(Clientdto client);
        public Task<bool> existsClient(int id);
    }
}
