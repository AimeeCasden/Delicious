using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using CRUDelicious.Models;

namespace CRUDelicious
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
            // CONFIGURE ALL SERVICES AND SQL CONNECTIONS BELOW
            string mySqlConnection = "server=localhost;userid=root;password=root;port=3306;database=mydb;SslMode=None";
             // Now we may use the connection string itself, bound to Configuration, to pass the required connection
            // credentials to MySQL
            services.AddDbContext<MyContext>(options => options.UseMySql(Configuration["DBInfo:ConnectionString"]));
            services.AddDbContext<MyContext>(options => options.UseMySql(mySqlConnection));
            services.AddSession();            
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            

            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}
