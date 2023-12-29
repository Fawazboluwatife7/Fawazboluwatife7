using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace aBookApp.Data
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public int? Name {get; set;}
        public string? Address {get; set;}
        public string? City {get; set;}
        public int? StateCode {get; set;}
        public int? PostalCode { get; set;}
    }
}
