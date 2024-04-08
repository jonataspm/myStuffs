using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace StreamAsync
{
    class MySitesAsync
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Starting Application...");
            string[] sites = { "https://google.com", "https://www.fbuni.edu.br", "https://www.ufc.br" };

            foreach (var site in sites)
            {
                await Task.Run(() => ProcessSiteAsync(site));
            }

            Console.WriteLine("Finishing Application...");
        }

        static async Task ProcessSiteAsync(string site)
        {
            try
            {
                using (var client = new WebClient())
                {
                    var data = await client.DownloadDataTaskAsync(site);

                    var name = site.Contains("www") ? site.Split('.')[1] : site.Split('.')[0].Substring(8);
                    var filePath = $"C:\\SistemaDistribuido\\{name}.html";

                    if (!File.Exists(filePath))
                    {
                        using (var stream = new FileStream(filePath, FileMode.CreateNew))
                        {
                            await stream.WriteAsync(data, 0, data.Length);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error processing {site}: {e.Message}");
            }
        }
    }
}
