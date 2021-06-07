using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(SmartGarage.Areas.Identity.IdentityHostingStartup))]
namespace SmartGarage.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}