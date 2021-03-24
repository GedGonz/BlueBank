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
            try
            {
                var _client = await getClientById(client.ClientId);
                _blueBankContext.Remove(_client);
                return await save();
            }
            catch (Exception)
            {

                throw;
            }



        }

        public async Task<IQueryable<Client>> getAllClients()
        {
            try
            {
                var ListAllClient = await Task.Factory.StartNew(() =>
                {
                    return _blueBankContext.Clients.AsQueryable();
                });

                return ListAllClient;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<Client> getClientById(Guid id)
        {
            try
            {
                return await _blueBankContext.Clients.FindAsync(id);
            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<bool> saveClient(Client client)
        {
            try
            {
                await _blueBankContext.Clients.AddAsync(client);
                return await save();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<bool> updateClient(Client client)
        {
            try
            {
                _blueBankContext.Update(client);
                return await save();
            }
            catch (Exception)
            {

                throw;
            }

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

        public async Task<bool> existsClient(Guid id)
        {
            try
            {
                var exists = await Task.Factory.StartNew(() =>
                {
                    return _blueBankContext.Clients.Any(x => x.ClientId == id);
                });

                return exists;
            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}
