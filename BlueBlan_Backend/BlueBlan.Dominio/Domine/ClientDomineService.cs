using BlueBlan.Dominio.Contracts;
using BlueBlan.Dominio.Entity;
using BlueBlan.Dominio.Services;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlueBlan.Dominio.Domine
{
    public class ClientDomineService : IClientDomineService
    {
        private readonly IClientRepository _clientRepository;
        public ClientDomineService(IClientRepository _clientRepository)
        {
            this._clientRepository = _clientRepository;
        }
        public async Task<bool> deleteClient(Client client)
        {
           return await _clientRepository.deleteClient(client);
        }

        public async Task<List<Client>> getAllClients()
        {
            var allClients=await _clientRepository.getAllClients();

            return allClients.ToList();
        }

        public async Task<Client> getClientById(Guid id)
        {
            return await _clientRepository.getClientById(id);
        }

        public async Task<bool> saveClient(Client client)
        {
            return await _clientRepository.saveClient(client);
        }

        public async Task<bool> updateClient(Client client)
        {
            return await _clientRepository.updateClient(client);
        }

        public async Task<bool> existsClient(Guid id)
        {
            return await _clientRepository.existsClient(id);
        }

    }
}
