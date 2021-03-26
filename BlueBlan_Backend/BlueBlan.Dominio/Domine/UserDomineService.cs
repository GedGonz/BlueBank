using BlueBlan.Dominio.Contracts;
using BlueBlan.Dominio.Entity;
using BlueBlan.Dominio.Services;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlueBlan.Dominio.Domine
{
    public class UserDomineService : IUserDomineService
    {
        private readonly IUserRepository _userRepository;
        //private readonly SignInManager<User> signInManager;
        //private readonly UserManager<User> _userManager;
        public UserDomineService(IUserRepository _userRepository/*, SignInManager<User> signInManager, UserManager<User> _userManager*/)
        {
            this._userRepository = _userRepository;
            //this.signInManager = signInManager;
            //this._userManager = _userManager;
        }
        public Task<bool> existsUser(string userName)
        {

            return _userRepository.existsUser(userName);
        }

        public async Task<User> findUser(string userName)
        {
            var _user = await _userRepository.findByNameUser(userName);
            return _user;
        }

        public async Task<bool> Authenticate(string username, string password)
        {
            var _user = await _userRepository.findByNameUser(username);
            //var user = await _userManager.FindByNameAsync(username);

            //var retorno = await signInManager.CheckPasswordSignInAsync(user, password, false);

            //return retorno.Succeeded;
            return true;
        }
    }
}
