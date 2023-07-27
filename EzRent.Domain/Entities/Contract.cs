namespace EzRent.Domain.Entities;

public class Contract : EntityBase
{
    public Guid ContractId { get; set; }
    public Client Client { get; set; }
    public Property Property { get; set; }
}