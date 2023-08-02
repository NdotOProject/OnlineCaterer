
using Microsoft.AspNetCore.Identity;
using OnlineCaterer.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace OnlineCaterer.Data.Identity;

public class ApplicationUser : IdentityUser
{
    [Required]
    public string? Name { get; set; }

    public string? Address { get; set; }

    public ICollection<Booking> Bookings { get; set; } = new HashSet<Booking>();

}
