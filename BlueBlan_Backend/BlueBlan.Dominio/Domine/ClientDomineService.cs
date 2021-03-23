using BlueBlan.Dominio.Contracts;
using BlueBlan.Dominio.Entity;
using BlueBlan.Dominio.Services;
using System;
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
        public async Task deleteClient(int id)
        {
            await _clientRepository.deleteClient(id);
        }

        public async Task<List<Client>> getAllClients()
        {
            var allClients=await _clientRepository.getAllClients();

            return (List<Client>)allClients;
        }

        public Task<Client> getClientById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task saveClient(Client client)
        {
            await _clientRepository.saveClient(client);
        }

        public async Task updateClient(Client client)
        {
            await _clientRepository.updateClient(client);
        }
    }
}
