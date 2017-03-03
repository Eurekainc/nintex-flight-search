namespace Nintex.Flight.Api.Models
{
    public class FlightEntry
    {
        public string AirlineLogoUrl { get; set; }
        public string AirlineName { get; set; }
        public int InBoundDuration { get; set; }
        public int OutBoundDuration { get; set; }
        public double TotalAmount { get; set; }
    }
}
