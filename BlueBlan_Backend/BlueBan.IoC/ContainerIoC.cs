using System;
using System.Collections.Generic;
using System.Text;
using BlueBan.Aplication.Contracts;
using BlueBan.Aplication.Services;
using BlueBlan.Dominio.Contracts;
using BlueBlan.Dominio.Domine;
using BlueBlan.Dominio.Entity;
using BlueBlan.Dominio.Services;
using BlueBlan.Infraestructura.Context;
using BlueBlan.Infraestructura.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace BlueBan.IoC
{
    public class ContainerIoC
    {
        public static IServiceCollection Services(IServiceCollection service) {

            service.AddScoped<IAccountRepository, AccountRepository>();
            service.AddScoped<IClientRepository, ClientRepository>();
            service.AddScoped<IAccountMoveRepository, AccountMoveRepository>();

            service.AddScoped<IAccountDomineService, AccountDomineService>();
            service.AddScoped<IClientDomineService, ClientDomineService>();
            service.AddScoped<IUserDomineService, UserDomineService>();

            service.AddScoped<IAccountAplicationService, AccountAplicationService>();
            service.AddScoped<IClientAplicationService, ClientAplicationService>();
            service.AddScoped<IUserAplicationService, UserAplicationService>();


            service.AddIdentity<User, IdentityRole>()
            .AddSignInManager<SignInManager<User>>()
            .AddUserManager<UserManager<User>>()
            .AddEntityFrameworkStores<BlueBankContext>()
            .AddDefaultTokenProviders();

            return service;
        }
    }
}
