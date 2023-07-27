using Microsoft.AspNetCore.Identity;

namespace EzRent.Domain.Entities;

public class ApplicationUser : IdentityUser
{
    public List<Contract> Contracts { get; set; }
}