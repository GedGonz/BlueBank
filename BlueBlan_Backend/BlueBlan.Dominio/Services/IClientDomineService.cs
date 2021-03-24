using BlueBlan.Dominio.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlueBlan.Dominio.Services
{
    public interface IClientDomineService
    {
        public Task<List<Client>> getAllClients();
        public Task<Client> getClientById(Guid id);
        public Task<bool> saveClient(Client client);
        public Task<bool> updateClient(Client client);
        public Task<bool> deleteClient(Client client);
        public Task<bool> existsClient(Guid id);
    }
}
