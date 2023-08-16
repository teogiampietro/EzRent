using System.ComponentModel.DataAnnotations;

namespace EzRent.Domain.Entities;

public class Product : EntityBase
{
    [Key]
    public int ProductId { get; set; }
    public string Description { get; set; }
    public double Cost { get; set; }
    public double Utility { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
    public int ItemsPerBox { get; set; }
    
    public Category Category { get; set; }
}

