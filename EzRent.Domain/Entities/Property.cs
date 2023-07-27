using System.ComponentModel.DataAnnotations;

namespace EzRent.Domain.Entities;

public class Property : EntityBase
{
    [Key]
    public int PropertyId { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public int RentPrice { get; set; }
    public int Environments { get; set; }
}