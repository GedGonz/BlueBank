using AutoMapper;
using BlueBan.Aplication.Contracts;
using BlueBan.Aplication.Entitydto;
using BlueBlan.Dominio.Entity;
using BlueBlan.Dominio.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlueBan.Aplication.Services
{
    public class AccountAplicationService : IAccountAplicationService
    {
        private readonly IAccountDomineService _accountDomineService;
        private readonly IMapper _mapper;

        public AccountAplicationService(IAccountDomineService _accountDomineService, IMapper _mapper)
        {
            this._accountDomineService = _accountDomineService;
            this._mapper = _mapper;
        }
        public async Task deleteAccount(int id)
        {
            await _accountDomineService.deleteAccount(id);
        }

        public async Task<Accountdto> getAccountById(int id)
        {
            var account= await _accountDomineService.getAccountById(id);

            var accountdto = _mapper.Map<Accountdto>(account);

            return accountdto;
        }

        public async  Task<List<Accountdto>> getAllAccounts()
        {
            var accounts = await _accountDomineService.getAllAccounts();

            var accountsdto = _mapper.Map<List<Accountdto>>(accounts);

            return accountsdto;
        }

        public async Task saveAccount(Accountdto account)
        {
            var _account = _mapper.Map<Account>(account);

            await _accountDomineService.saveAccount(_account);
        }

        public async Task updateAccount(Accountdto account)
        {
            var _account = _mapper.Map<Account>(account);

            await _accountDomineService.updateAccount(_account);
        }
    }
}
