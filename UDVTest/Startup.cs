using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using UDVTest.Repository;
using UDVTest.SortingAlgorithms;

namespace UDVTest
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            var algorithm = Configuration["Algorithm"];
            switch (algorithm)
            {
                case HandShuffle.Name:
                    services.AddScoped<IShuffle, HandShuffle>();
                    break;
                case SimpleShuffle.Name:
                    services.AddScoped<IShuffle, SimpleShuffle>();
                    break;
                default:
                    throw new Exception("Wrong algorithm");
            };
            services.AddSingleton<IRepository<CardDeck>, DeckRepository>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DeckSorter.Api", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DeckSorter.Api v1"));
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}