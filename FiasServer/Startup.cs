#region License
// // Разработано: Коротенко Владимиром Николаевичем (Vladimir N. Korotenko)
// // email: koroten@ya.ru
// // skype:vladimir-korotenko
// // https://vkorotenko.ru
// // Создано:  26.07.2020 15:04
#endregion

using AspNetCoreRateLimit;
using FiasServer.Code;
using FiasServer.Data;
using FiasServer.Models;
using IdentityServer4.Models;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SpaServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System.Linq;
using FiasServer.Services;
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
            services.
                AddIdentity<ApplicationUser,ApplicationRole>()
                // AddDefaultIdentity<ApplicationUser>()
                .AddRoles<ApplicationRole>()
                .AddClaimsPrincipalFactory<ClaimsFactory>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                ;

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddIdentityServerAuthentication();
            services.AddAuthorization(options =>
            {
                options.AddPolicy("ShouldHasUsersGroup", policy => { policy.RequireClaim("hasUsersGroup"); });
            });
            services.AddIdentityServer(opt =>
                {
                    opt.Events.RaiseErrorEvents = true;
                    opt.Events.RaiseInformationEvents = true;
                    opt.Events.RaiseFailureEvents = true;
                    opt.Events.RaiseSuccessEvents = true;
                })
                .AddOperationalStore(options =>
                {
                    options.ConfigureDbContext = builder => builder.UseSqlite(Configuration.GetConnectionString("DefaultConnection"));
                    options.EnableTokenCleanup = true;
                    options.TokenCleanupInterval = 30; // interval in seconds
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
                    apiResource.UserClaims = new[] { "hasUsersGroup", "role" };

                    var identityResource = new IdentityResource
                    {
                        Name = "customprofile",
                        DisplayName = "Custom profile",
                        UserClaims = new[] { "hasUsersGroup", "role" },
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
                .AddIdentityServerJwt();

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
                            // и другие хосты через запятую
                            .WithOrigins(ServerUrl)
                            .SetIsOriginAllowedToAllowWildcardSubdomains()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });
            services.Configure<IISOptions>(iis =>
            {
                iis.AuthenticationDisplayName = "Windows";
                iis.AutomaticAuthentication = false;
            });

            // ..or configures IIS in-proc settings
            services.Configure<IISServerOptions>(iis =>
            {
                iis.AuthenticationDisplayName = "Windows";
                iis.AutomaticAuthentication = false;
            });

            // needed to load configuration from appsettings.json
            services.AddOptions();

            // needed to store rate limit counters and ip rules
            services.AddMemoryCache();

            //load general configuration from appsettings.json
            services.Configure<IpRateLimitOptions>(Configuration.GetSection("IpRateLimiting"));

            // inject counter and rules stores
            services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
            services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
            // https://github.com/aspnet/Hosting/issues/793
            // the IHttpContextAccessor service is not registered by default.
            // the clientId/clientIp resolvers use it.
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // configuration (resolvers, counter key builders)
            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();

            //todo: Добавить лимиты https://github.com/stefanprodan/AspNetCoreRateLimit/wiki

            services.AddTransient<DbSeeder>();
            services.AddTransient<AdminInfoService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DbSeeder dbSeeder)
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

            dbSeeder.Seed();
            app.UseIpRateLimiting();
            
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
                endpoints.MapControllerRoute("api", "api/{controller=User}");
                endpoints.MapControllerRoute("api", "api/{controller=Admin}");
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
