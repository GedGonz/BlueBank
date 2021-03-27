using AutoMapper;
using BlueBan.Aplication.Contracts;
using BlueBan.Aplication.Entitydto;
using BlueBlan.Dominio.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlueBan.Aplication.Services
{
    public class UserAplicationService : IUserAplicationService
    {
        private readonly IUserDomineService _userDoimneService;
        private readonly IMapper _mapper;
        private readonly ILogger<AccountAplicationService> _logger;
        public UserAplicationService(IUserDomineService _userDoimneService, IMapper _mapper, ILogger<AccountAplicationService> _logger)
        {
            this._userDoimneService = _userDoimneService;
            this._mapper = _mapper;
            this._logger = _logger;
        }

        public async Task<bool> Authenticate(string username, string password)
        {
            return await _userDoimneService.Authenticate(username, password);
        }


        public async Task<Userdto> findUser(string userName)
        {
            var user=await _userDoimneService.findUser(userName);

            var userdto = _mapper.Map<Userdto>(user);
            return userdto;
        }
    }
}
