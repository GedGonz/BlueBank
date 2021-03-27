using AutoMapper;
using BlueBan.Aplication.Contracts;
using BlueBan.Aplication.Entitydto;
using BlueBlan.Dominio.Entity;
using BlueBlan.Dominio.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlueBan.Aplication.Services
{
    public class ClientAplicationService : IClientAplicationService
    {
        private readonly IClientDomineService _clientDomineService;

        private readonly ILogger<ClientAplicationService> _logger;
        private readonly IMapper _mapper;

        public ClientAplicationService(IClientDomineService _clientDomineService, ILogger<ClientAplicationService> _logger,IMapper _mapper)
        {
            this._clientDomineService = _clientDomineService;
            this._logger = _logger;
            this._mapper = _mapper;
        }
        public async Task<bool> deleteClient(Clientdto client)
        {
             var _client = _mapper.Map<Client>(client);
            return await _clientDomineService.deleteClient(_client);
        }

        public async Task<List<Clientdto>> getAllClients()
        {
            var clients = await _clientDomineService.getAllClients();

            var clientsdto = _mapper.Map<List<Clientdto>>(clients);

            return clientsdto;
        }

        public async Task<Clientdto> getClientById(Guid id)
        {
            var client = await _clientDomineService.getClientById(id);

            var clientdto = _mapper.Map<Clientdto>(client);

            return clientdto;
        }

        public async Task<bool> saveClient(Clientdto client)
        {
            var _client = _mapper.Map<Client>(client);

            var isSave =await _clientDomineService.saveClient(_client);

            if (isSave) 
            {
                _logger.LogInformation($"Delete Account {client.ToString()}");
            }

            return isSave;
        }

        public async Task<bool> updateClient(Clientdto client)
        {
            var _client = _mapper.Map<Client>(client);

            return await _clientDomineService.updateClient(_client);
        }

        public async Task<bool> existsClient(Guid id)
        {
            return await _clientDomineService.existsClient(id);
        }

    }
}
