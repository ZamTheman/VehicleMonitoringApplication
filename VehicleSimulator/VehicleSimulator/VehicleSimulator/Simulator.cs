using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VehicleSimulator
{
    public class Simulator : IHostedService, IDisposable
    {
        private Timer timer;
        private readonly string url;

        public Simulator(IConfiguration configuration)
        {
            url = configuration.GetSection("Api").Value;
        }

        private static List<string> Vins = new List<string>
        {
            "YS2R4X20005399401",
            "VLUR4X20009093588",
            "VLUR4X20009048066",
            "YS2R4X20005388011",
            "YS2R4X20005387949",
            "YS2R4X20005387765",
            "YS2R4X20005387055"
        };

        public void Dispose()
        {
            timer?.Dispose();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            timer = new Timer(DoSimulation, null, TimeSpan.Zero, TimeSpan.FromMinutes(1));

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void DoSimulation(object state)
        {
            var httpClient = HttpClientFactory.Create();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var random = new Random();

            foreach (var vin in Vins)
            {
                if (random.Next(5) == 4)
                    continue;

                var request = new HttpRequestMessage(HttpMethod.Post, url);
                request.Content = new StringContent(JsonConvert.SerializeObject(vin), Encoding.UTF8, "application/json");
                var result = httpClient.SendAsync(request);
                var endResult = result.Result;
            }
        }
    }
}
