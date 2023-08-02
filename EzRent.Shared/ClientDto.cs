namespace EzRent.Shared;

public class ClientDto
{
    public int ClientId { get; set; }
    public int? PersonalId { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
}