﻿using BlueBlan.Dominio.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBlan.Dominio.Contracts
{
    public interface IClientRepository
    {
        public Task<IQueryable<Client>> getAllClients();
        public Task<Client> getClientById(Guid id);
        public Task<bool> saveClient(Client client);
        public Task<bool> updateClient(Client client);
        public Task<bool> deleteClient(Client client);
        public Task<bool> existsClient(Guid id);
        public Task<bool> save();
    }
}
