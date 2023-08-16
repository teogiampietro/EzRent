using System.ComponentModel.DataAnnotations;

namespace EzRent.Domain.Entities;

public class Order
{
    [Key]
    public int OrderId { get; set; }
    public Client Client { get; set; }
    public List<OrderItems> OrderItems { get; set; }
}