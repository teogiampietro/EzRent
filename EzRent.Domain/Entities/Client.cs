using System.ComponentModel.DataAnnotations;

namespace EzRent.Domain.Entities;

public class Client : EntityBase
{
    [Key]
    public Guid ClientId { get; set; }

    public string Name { get; set; }
    public string Surname { get; set; }
    public int PersonalId { get; set; }
    public string Email { get; set; }
}