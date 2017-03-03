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

        public List<FlightEntry> GetFlights(string result)
        {
            var flightResult = JsonConvert.DeserializeObject<AirLineTwoResult>(result);

            return flightResult.Results;
        }
    }
}
