using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using dotnet_redis.Servicos;
using dotnet_redis.Repositorio;

namespace dotnet_redis
{
    public class Startup
    {

    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    var clientesCache = ClienteCache.Todos();
                    var clientes = ClienteDb.Todos();
                    await context.Response.WriteAsync($"Quantidade de cientes em cache {clientesCache.Count}");
                    await context.Response.WriteAsync($"\nQuantidade de clientes sem cache {clientes.Count}");
                });

                endpoints.MapGet("/add-cache", async context =>
                {
                    var clientes = ClienteDb.Todos();
                    ClienteCache.AdicionarNoCache(clientes);

                    await context.Response.WriteAsync("Clientes adicionados no cache");
                });

                endpoints.MapGet("/remove-cache", async context =>
                {
                    ClienteCache.LimpaCache();
                    await context.Response.WriteAsync("Cache limpo");
                });
            });
        }
    }
}
