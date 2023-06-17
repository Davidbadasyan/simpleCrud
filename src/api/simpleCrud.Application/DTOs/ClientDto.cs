namespace simpleCrud.Application.DTOs;

public class ClientDto
{
    public int Id { get; set; }
    public string? Code { get; set; }
    public string? Name { get; set; }
    public string? EntityType { get; set; }
    public DateTime? DateInception { get; set; }
    public DateTime? DateTermination { get; set; }
    public string? TerminationReason { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public int IdTeam { get; set; }
    public AddressDto? Address { get; set; }
}