using PuppeteerSharp;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace SmartGarage.Service
{
    public class PdfService
    {
        public async Task<Stream> GeneratePdf(List<int> services)
        {
            await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultRevision);
            var browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = true
            });
            using (var page = await browser.NewPageAsync())
            {
                await page.SetContentAsync($"<div style=\"color: blue;\">Content</div>");
                return await page.PdfStreamAsync();
            }
        }

        public async Task<Stream> GeneratePdf()
        {
            await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultRevision);
            var browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = true
            });
            using (var page = await browser.NewPageAsync())
            {
                await page.SetContentAsync($"<div style=\"color: blue;\">Content</div>");
                return await page.PdfStreamAsync();
            }
        }
    }
}
