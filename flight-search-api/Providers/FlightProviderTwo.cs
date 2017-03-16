using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nintex.Flight.Api.Models;
using Newtonsoft.Json;

namespace Nintex.Flight.Api
{
    public class FlightProviderTwo : IFlightProvider
    {
        public string ProviderURL
        {
            get
            {
                return "http://nmflightapi.azurewebsites.net/api/AirlineTwo";
            }
        }

        public async Task<List<FlightEntry>> GetFlights(string result)
        {
            await Task.Delay(10000).ConfigureAwait(false);

            var flightResult = JsonConvert.DeserializeObject<AirLineTwoResult>(result);

            return flightResult.Results;
        }
    }
}
