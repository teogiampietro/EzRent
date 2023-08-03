namespace EzRent.Shared;

public class ProductDto
{
    public int ProductId { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
    public int ItemsPerBox { get; set; }
}