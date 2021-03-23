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
    public class ClieneRepository : IClientRepository
    {
        private BlueBankContext _blueBankContext;

        public ClieneRepository(BlueBankContext _blueBankContext)
        {
            this._blueBankContext = _blueBankContext;
        }
        public async Task deleteClient(int id)
        {
            var client = await getClientById(id);
            if (client != null)
            {
                _blueBankContext.Remove(client);
                await _blueBankContext.SaveChangesAsync();
            }
        }

        public async Task<IQueryable<Client>> getAllClients()
        {
            var ListAllClient = await Task.Factory.StartNew(() =>
            {
                return _blueBankContext.Clients.AsQueryable();
            });

            return ListAllClient;
        }

        public async Task<Client> getClientById(int id)
        {
            return await _blueBankContext.Clients.FindAsync(id);
        }

        public async Task saveClient(Client client)
        {
            await _blueBankContext.Clients.AddAsync(client);
            await _blueBankContext.SaveChangesAsync();
        }

        public async Task updateClient(Client client)
        {
            var _client = await getClientById(client.ClientId);
            if (_client != null)
            {
                _client.Name = client.Name;
                _client.LastName = client.LastName;

                _blueBankContext.Remove(_client);
                await _blueBankContext.SaveChangesAsync();
            }
        }
    }
}
