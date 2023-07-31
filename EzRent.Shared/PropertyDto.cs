namespace EzRent.Shared;

public class PropertyDto
{
    public int PropertyId { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public int RentPrice { get; set; }
    public int Environments { get; set; }
}