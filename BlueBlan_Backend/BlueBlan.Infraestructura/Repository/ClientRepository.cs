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
    public class ClientRepository : IClientRepository
    {
        private BlueBankContext _blueBankContext;

        public ClientRepository(BlueBankContext _blueBankContext)
        {
            this._blueBankContext = _blueBankContext;
        }
        public async Task<bool> deleteClient(Client client)
        {
            var _client = await getClientById(client.ClientId);
            _blueBankContext.Remove(_client);
            return await save();


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


        public async Task<bool> saveClient(Client client)
        {
            await _blueBankContext.Clients.AddAsync(client);
            return await save();
        }

        public async Task<bool> updateClient(Client client)
        {

            _blueBankContext.Update(client);
            return await save();

        }

        public async Task<bool> save()
        {
            var save = 0;
            var retorno = false;
            try
            {
                save = await _blueBankContext.SaveChangesAsync();
                retorno = save >= 0;

            }
            catch (Exception)
            {

                throw;
            }

            return retorno;
        }

        public async Task<bool> existsClient(int id)
        {
            var exists = await Task.Factory.StartNew(() =>
            {
                return _blueBankContext.Clients.Any(x => x.ClientId == id);
            });

            return exists;
        }

    }
}
