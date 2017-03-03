using System;
using System.ComponentModel.DataAnnotations;

namespace Nintex.Flight.Client.Models
{
    public class SearchViewModel
    {
        [Required]
        [StringLength(3, ErrorMessage = "Enter 3 character", MinimumLength = 3)]
        [Display(Name = "Departure Airport Code")]
        public string DepartureAirportCode { get; set; }

        [Required]
        [StringLength(3, ErrorMessage = "Enter 3 character", MinimumLength = 3)]
        [Display(Name = "Arrival Airport Code")]
        public string ArrivalAirportCode { get; set; }

        [Required]
        [Display(Name = "Departure Date")]
        public DateTime DepartureDate { get; set; }

        [Required]
        [Display(Name = "Return Date")]
        public DateTime ReturnDate { get; set; }
    }
}
