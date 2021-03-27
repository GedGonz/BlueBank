using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlueBan.Aplication.Mapper;
using BlueBan.IoC;
using BlueBlan.Dominio.Entity;
using BlueBlan.Infraestructura.Context;
using BlueBlan_API.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace BlueBlan_Backend
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            //services.AddControllers();
            services.AddControllers().AddNewtonsoftJson(options =>
               options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            services.AddDbContext<BlueBankContext>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("BluBankDB"));
                options.UseSqlServer().UseLazyLoadingProxies();
            });


            string secret = this.Configuration.GetSection("AppSettings:Token").Value;

            byte[] secretByte = Encoding.UTF8.GetBytes(secret);

            var key = new SymmetricSecurityKey(secretByte);

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ValidIssuer = this.Configuration.GetSection("AppSettings:Issuer").Value,
                    ValidAudience = this.Configuration.GetSection("AppSettings:Issuer").Value,
                    IssuerSigningKey = key
                };
            });

            //Configure AutoMapper
            services.AddAutoMapper(typeof(MappingProfile));

            //Configure IOC
            ContainerIoC.Services(services);
            //enable requetes cors
            services.AddCors();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //app.ConfigureExceptionHandler();

            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) 
                .AllowCredentials());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

          
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
