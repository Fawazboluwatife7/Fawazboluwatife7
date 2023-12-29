using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace aBookApp.Models
{
    public class ApplicationUser: IdentityUser 
    {
        [Required]
        public string Name {  get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Address { get; set; }

    }
}
