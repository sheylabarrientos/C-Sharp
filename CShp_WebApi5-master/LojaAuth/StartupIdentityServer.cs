using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using IdentityServer4.Validation;
using IdentityServer4.Services;
using LojaAuth.Api.Models;
using LojaAuth.Services;

namespace LojaAuth
{
    public class StartupIdentityServer
    {
        public IHostingEnvironment Environment { get; }

        public StartupIdentityServer(IHostingEnvironment environment)
        {
            Environment = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            //config contexto
            services.AddDbContext<LojaContexto>();

            // add interface - services - classe de validação de senha
            services.AddScoped<IResourceOwnerPasswordValidator, ValidadorSenhaService>();

            // add scoped - interface de validação - classe de perfil de usuario
            services.AddScoped<IProfileService, UserProfileService>();

            //start classe identity config
            var builder = services.AddIdentityServer()
                .AddInMemoryIdentityResources(IdentityConfig.GetRecursosIdentity())
                .AddInMemoryApiResources(IdentityConfig.GetApis())
                .AddInMemoryClients(IdentityConfig.GetClients())
                .AddProfileService<UserProfileService>();

            //ambiente
            if (Environment.IsDevelopment())
            {
                builder.AddDeveloperSigningCredential();
            }
            else
            {
                throw new Exception("ambiente de produção precisa de chave real");
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {                        
            //app.UseStaticFiles();
            app.UseIdentityServer();            
        }
    }
}
