using Nintex.Flight.Api.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Nintex.Flight.Api
{
    public class FlightService
    {
        private List<IFlightProvider> flightProviders;

        public FlightService(List<IFlightProvider> providers)
        {
            this.flightProviders = providers;
        }

        public async Task<List<FlightEntry>> Search()
        {
            var result = new List<FlightEntry>();

            await Task.WhenAll(this.flightProviders.Select(async f => result.AddRange(await this.GetFlights(f))));

            //List<Task<List<FlightEntry>>> TaskList = new List<Task<List<FlightEntry>>>();

            //foreach(var provider in this.flightProviders)
            //{
            //    var lastTask = this.GetFlights(provider);
            //    TaskList.Add(lastTask);
            //}

            //var resultArray = await Task.WhenAll(TaskList);

            //foreach (var arrayOfFlight in resultArray)
            //{
            //    result.AddRange(arrayOfFlight);
            //}

            return result;
        }

        private async Task<List<FlightEntry>> GetFlights(IFlightProvider provider)
        {
            var result = new List<FlightEntry>();
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(new Uri(provider.ProviderURL));

                if (response.IsSuccessStatusCode)
                {
                    result = await provider.GetFlights(await response.Content.ReadAsStringAsync());
                }
            }

            return result;
        }
    }
}
