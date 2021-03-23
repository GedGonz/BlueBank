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
        public Task<Client> getClientById(int id);
        public Task saveClient(Client client);
        public Task updateClient(Client client);
        public Task deleteClient(int id);
    }
}
