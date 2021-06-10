using PuppeteerSharp;
using SmartGarage.Service.DTOs.GetDTOs;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGarage.Service
{
    public class PdfService
    {
        public async Task<Stream> GeneratePdf(GetOrderDTO order)
        {
            await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultRevision);
            var browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = true
            });
            using (var page = await browser.NewPageAsync())
            {
                var sb = new StringBuilder();
                sb.AppendLine($"<div style=\"color: black; margin-left:310px\"><h1>Order Details</h1></div>");
                sb.AppendLine("<hr>");
                sb.AppendLine($"<div style=\"color: black; margin-left:260px\"><h2>Customer Name:{order.CustomerName}</h></div>");
                order.Services.ForEach(s => sb.AppendLine($"<div style=\"color: black; margin-left:310px\"><h4>{s.Name} {s.Price}EUR</h4></div>"));
                var totalPrice = order.Services.Sum(s => s.Price);
                sb.AppendLine("<hr>");
                sb.AppendLine($"<div style=\"color: black; margin-left:550px\"><h2>Total Price:{totalPrice} EUR</h2></div>");
                await page.SetContentAsync(sb.ToString());
                return await page.PdfStreamAsync();
            }
        }
    }
}
