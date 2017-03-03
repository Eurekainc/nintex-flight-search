using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nintex.Flight.Api.Models;
using Newtonsoft.Json;

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

        public List<FlightEntry> GetFlights(string result)
        {
            return JsonConvert.DeserializeObject<List<FlightEntry>>(result);
        }
    }
}
