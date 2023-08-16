using Microsoft.AspNetCore.Identity;

namespace EzRent.Domain.Entities;

public class ApplicationUser : IdentityUser
{
    public List<Order> Properties { get; set; }
}