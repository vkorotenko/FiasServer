using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(FiasServer.Areas.Identity.IdentityHostingStartup))]
namespace FiasServer.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}