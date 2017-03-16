using Newtonsoft.Json;
using Nintex.Flight.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nintex.Flight.Api
{
    public class FlightProviderOne : IFlightProvider
    {
        public string ProviderURL
        {
            get
            {
                return "http://nmflightapi.azurewebsites.net/api/airlineone";
            }
        }

        public async Task<List<FlightEntry>> GetFlights(string result)
        {
            return JsonConvert.DeserializeObject<List<FlightEntry>>(result);
        }
    }
}
