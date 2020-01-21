using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using dotenv.net;
using dotenv.net.DependencyInjection.Extensions;
using System.Text;
using LibraryData.Models.Common;
using Library.Services;

namespace Library
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // used for the services layer. IOC container. Want to inject teh services using D.I
        public void ConfigureServices(IServiceCollection services)
        {
            DotEnv.Config();
            services.AddEnv(builder => {
                builder
                .AddEnvFile("./.env")
                .AddThrowOnError(false)
                .AddEncoding(Encoding.ASCII);
            });

            var connectionString = Environment.GetEnvironmentVariable("POSTGRES_CONNECTION_STRING");

            services.AddControllersWithViews();
            services.AddEntityFrameworkNpgsql();
            services.AddDbContext<LibraryContext>(options =>
            options.UseNpgsql(connectionString));
            // add any new services in the service layer here
            services.AddSingleton(Configuration);
            // this service will get injected into the catalogue controller when it asks for the IBorrowable interface
            services.AddScoped<IBorrowable, LibraryItemService>();  
        }

        // MIDDLEWARE
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
