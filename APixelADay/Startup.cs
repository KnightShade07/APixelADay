using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APixelADay.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace APixelADay
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
            services.AddTransient<BlobStorageHelper, BlobStorageHelper>();
            //AddDbContextPool is better than DbContext because it does not
            //create a new connection every single time this is called,
            //it checks for an existing Dbcontext method.
            services.AddDbContextPool<PixelDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("PixelArtDBConnection")));
            services.AddDefaultIdentity<IdentityUser>(IdentityHelper.SetIdentityOptions)
                .AddRoles<IdentityRole>().AddEntityFrameworkStores<PixelDBContext>();
            services.AddRazorPages();
           
            services.AddControllersWithViews();
        }

        

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
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

            //Create roles here!
            IServiceScope serviceProvider = app.ApplicationServices.GetRequiredService<IServiceProvider>().CreateScope();

            IdentityHelper.CreateRoles(serviceProvider.ServiceProvider, IdentityHelper.Administrator, IdentityHelper.User).Wait();

            IdentityHelper.CreateDefaultAdministrator(serviceProvider.ServiceProvider).Wait();

        }
    }
}
