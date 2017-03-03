using Nintex.Flight.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nintex.Flight.Api
{
    public interface IFlightProvider
    {
        string ProviderURL { get; }

        List<FlightEntry> GetFlights(string result);
    }
}
