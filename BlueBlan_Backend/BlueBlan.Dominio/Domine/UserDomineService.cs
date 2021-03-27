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
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> _userManager;
        public UserDomineService(SignInManager<User> signInManager, UserManager<User> _userManager)
        {
            this.signInManager = signInManager;
            this._userManager = _userManager;
        }


        public async Task<User> findUser(string userName)
        {
            var _user = await _userManager.FindByNameAsync(userName);
            return _user;
        }

        public async Task<bool> Authenticate(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);

            var retorno = await signInManager.CheckPasswordSignInAsync(user, password, false);

            return retorno.Succeeded;
        }
    }
}
