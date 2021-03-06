﻿using CodingTest.Domain.Configurations;
using CodingTest.Domain.Stories;
using HackerNews.Provider;
using HackerNews.Provider.Configurations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace CodingTest
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
            services.AddMemoryCache();

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                });

            var hackerNewsApiConfigurations = new HackerNewsApiConfigurations();
            Configuration.Bind("HackerNewsApiConfigurations", hackerNewsApiConfigurations);
            services.AddSingleton<IHackerNewsApiConfigurations>(hackerNewsApiConfigurations);
            
            var storiesConfigurations = new StoriesConfigurations();
            Configuration.Bind("StoriesConfigurations", storiesConfigurations);
            services.AddSingleton<IStoriesConfigurations>(storiesConfigurations);
            
            services.AddSingleton<IStories, Stories>();
            services.AddSingleton<IHackerNewsAPI, HackerNewsAPI>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
