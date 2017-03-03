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

            foreach (var provider in this.flightProviders)
            {
                result.AddRange(this.GetFlights(provider).Result);
            }
            

            return result;
        }

        private async Task<List<FlightEntry>> GetFlights(IFlightProvider provider)
        {
            var result = new List<FlightEntry>();
            using (var client = new HttpClient())
            {
                //client.BaseAddress = new Uri("http://nmflightapi.azurewebsites.net/api/AirlineOne");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(new Uri(provider.ProviderURL));
                if (response.IsSuccessStatusCode)
                {
                    result = provider.GetFlights(response.Content.ReadAsStringAsync().Result);
                }
            }

            return result;
        }
    }
}
