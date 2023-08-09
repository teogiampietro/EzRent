namespace EzRent.Shared;

public class StockUpdateDto
{
    public int ProductId { get; set; }
    public string Description { get; set; }
    public int Quantity { get; set; }
}