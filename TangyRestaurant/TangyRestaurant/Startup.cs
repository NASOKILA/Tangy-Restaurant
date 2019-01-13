using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TangyRestaurant.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TangyRestaurant.Models;
using System.Globalization;
using TangyRestaurant.Utility;

namespace TangyRestaurant
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            //SetUp Identity and Identity roles
            services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            
            //OAuth Authentication for FaceBook  01.Go to https://developers.facebook.com ,  02.Create an app,  03.SetUp credential 
            services.AddAuthentication().AddFacebook(facebookOptions =>
            {
                //We setup the AppId and App Secret
                facebookOptions.AppId = OAuthKeys.FacebookAppId;
                facebookOptions.AppSecret = OAuthKeys.FacebookAppSecret;
            });

            
            //OAuth Google Authentication, 01.Go to https://console.developers.google.com ,  02.Create an app,  03.Enable google + API service
            services.AddAuthentication().AddGoogle(googleOptions =>
            {
                //With google we have ClientID and ClientSecret
                googleOptions.ClientId = OAuthKeys.GoogleClientId;
                googleOptions.ClientSecret = OAuthKeys.GooleClientSecret;
            });
            

            services.AddIdentityCore<ApplicationUser>(options =>
                {
                    options.Lockout.AllowedForNewUsers = true;
                    options.Lockout.MaxFailedAccessAttempts = 3;
                     // The user is locked for 5 minutes by default, we can set it for 3 mins
                })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            //services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            //{
            //    options.Lockout.AllowedForNewUsers = true;
            //    options.Lockout.MaxFailedAccessAttempts = 3; 
            //    options.Lockout.DefaultLockoutTimeSpan = new TimeSpan(3); // The user is locked for 5 minutes by default, we set it for 3 mins
            //})
            //.AddEntityFrameworkStores<ApplicationDbContext>()
            //.AddDefaultTokenProviders();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //Add sessions to our app
            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(30); //This determines how long the the session will be active !!!
                options.Cookie.HttpOnly = true; //This session will be in the cookie !!!
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }


            var cultureInfo = new CultureInfo("en-US");
            cultureInfo.NumberFormat.CurrencySymbol = "€";

            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
            
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseSession();
            app.UseAuthentication();
            
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }
    }
}
