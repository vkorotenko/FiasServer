#region License
// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  26.07.2020 15:04
#endregion

using FiasServer.Data;
using FiasServer.Models;
using IdentityServer4.Models;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System.Linq;
using VueCliMiddleware;

namespace FiasServer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            ServerUrl = configuration.GetSection("ServerUri").Value;
        }

        private string ServerUrl;
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<ApplicationUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddIdentityServerAuthentication();
            services.AddIdentityServer(opt =>
                {
                    opt.Events.RaiseErrorEvents = true;
                    opt.Events.RaiseInformationEvents = true;
                    opt.Events.RaiseFailureEvents = true;
                    opt.Events.RaiseSuccessEvents = true;
                })
                .AddApiAuthorization<ApplicationUser, ApplicationDbContext>(options =>
                {
                    var cl = options.Clients;
                    var fias = cl.First();
                    fias.AllowedGrantTypes.Clear();
                    foreach (var env in GrantTypes.ImplicitAndClientCredentials)
                    {
                        fias.AllowedGrantTypes.Add(env);
                    }
                    var apiResource = options.ApiResources.First();
                    apiResource.UserClaims = new[] { "hasUsersGroup" };

                    var identityResource = new IdentityResource
                    {
                        Name = "customprofile",
                        DisplayName = "Custom profile",
                        UserClaims = new[] { "hasUsersGroup" },
                    };
                    identityResource.Properties.Add(ApplicationProfilesPropertyNames.Clients, "*");
                    options.IdentityResources.Add(identityResource);
                });
            services.AddAuthentication()
                .AddOpenIdConnect("Google", "Google",
                    o =>
                    {
                        var googleAuthNSection = Configuration.GetSection("Authentication:Google");
                        o.ClientId = googleAuthNSection["ClientId"];
                        o.ClientSecret = googleAuthNSection["ClientSecret"];
                        o.Authority = "https://accounts.google.com";
                        o.ResponseType = OpenIdConnectResponseType.Code;
                        o.CallbackPath = "/signin-google";
                    })
                .AddIdentityServerJwt()
                ;
            services.AddControllers();
            services.AddRazorPages();
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "Client/dist";
            });
            services.AddSwaggerGen();
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder =>
                    {
                        builder
                            .AllowCredentials()
                            .WithOrigins(ServerUrl, "https://localhost:44357")
                            .SetIsOriginAllowedToAllowWildcardSubdomains()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "FIAS server API");
            });
            if (env.IsDevelopment())
            {
                IdentityModelEventSource.ShowPII = true;
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
                app.UseHttpsRedirection();
            }



            app.UseStaticFiles();
            // PRODUCTION uses webpack static files
            app.UseSpaStaticFiles();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseIdentityServer();
            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("api", "api/{controller=Address}");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");

                if (env.IsDevelopment())
                {
                    endpoints.MapToVueCliProxy(
                        "{*path}",
                        new SpaOptions { SourcePath = "Client" },
                        npmScript: "serve",
                        regex: "Compiled successfully");
                }

                // Add MapRazorPages if the app uses Razor Pages. Since Endpoint Routing includes support for many frameworks, adding Razor Pages is now opt -in.
                endpoints.MapRazorPages();
                endpoints.MapControllers();
            });
            app.UseSpa(spa =>
            {
                if (env.IsDevelopment())
                    spa.Options.SourcePath = "Client";
                else
                    spa.Options.SourcePath = "dist";
                if (env.IsDevelopment())
                {
                    spa.UseVueCli(npmScript: "serve");
                }
            });

        }
    }
}
