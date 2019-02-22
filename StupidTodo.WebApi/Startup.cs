﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using StupidTodo.Domain;

namespace StupidTodo.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc()
                .UseCors(builder => builder.WithOrigins("*")
                                            .AllowAnyMethod()
                                            .AllowAnyHeader()
                                            .AllowCredentials());
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services = ExploreConfiguration(services);

            services.AddCors()
                    .AddMvc();
        }

        private IServiceCollection ExploreConfiguration(IServiceCollection services)
        {
            // Equivalent ways to get simple config settings
            string fav1 = Configuration.GetSection("favoriteBeerStyle")?.Value;
            string fav2 = Configuration["favoriteBeerStyle"];

            // Get complex data, very resilient
            string current = Configuration["beerOfTheNow:name"];
            string currentBreweryName = Configuration["beerOfTheNow:brewery:name"];
            string badName = Configuration["beerOfTheNow:BAD_NAME!_no_beer_for_you"];

            // Bind to an object then setup for DI
            var beer = new TheBeer();
            Configuration.GetSection("beerOfTheNow").Bind(beer);
            services.AddSingleton(beer);

            // A more elegant method?
            services.AddSingleton(Configuration.GetSection("beerOfTheNow")?.Get<TheBeer>());

            // The Configure method resolves depenencies of type IOptions<TOption>
            services.Configure<TheBeer>(Configuration.GetSection("beerOfTheNow"));

            // Collections
            services.AddSingleton(Configuration.GetSection("todos")?.Get<Todo[]>()?.ToList());
            services.Configure<List<Todo>>(Configuration.GetSection("todos"));

            return services;
        }


        public IConfiguration Configuration { get; }
    }
}
