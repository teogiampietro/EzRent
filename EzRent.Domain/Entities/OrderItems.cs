using System.ComponentModel.DataAnnotations;

namespace EzRent.Domain.Entities;

public class OrderItems
{    
    [Key]
    public int OrderItemsId { get; set; }
    public Product Product { get; set; }
    public int  Quantity { get; set; }
    public int  Price { get; set; }
}