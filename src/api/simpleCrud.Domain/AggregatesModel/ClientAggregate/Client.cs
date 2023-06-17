using simpleCrud.Domain.Exceptions;

namespace simpleCrud.Domain.AggregatesModel.ClientAggregate;

public class Client : Entity, IAggregateRoot
{
    public string? Code { get; protected set; }
    public string? Name { get; protected set; }
    public string? EntityType { get; protected set; }
    public DateTime? DateInception { get; protected set; }
    public DateTime? DateTermination { get; protected set; }
    public string? TerminationReason { get; protected set; }
    public string? Email { get; protected set; }
    public string? Phone { get; protected set; }
    public int IdTeam { get; protected set; }
    public Address? Address { get; protected set; }

    protected Client()
    {

    }

    protected Client(
        string? code,
        string? name,
        string? entityType,
        DateTime? dateInception,
        DateTime? dateTermination,
        string? terminationReason,
        string? email,
        string? phone,
        int idTeam,
        Address? address)
    {
        Code = code;
        Name = name;
        EntityType = entityType;
        DateInception = dateInception;
        DateTermination = dateTermination;
        TerminationReason = terminationReason;
        Email = email;
        Phone = phone;
        IdTeam = idTeam;
        Address = address;
    }

    public static async Task<Client> Create(
        IClientQueryRepository clientQueryRepository,
        string? code,
        string? name,
        string? entityType,
        DateTime? dateInception,
        DateTime? dateTermination,
        string? terminationReason,
        string? email,
        string? phone,
        int idTeam,
        Address? address)
    {
        if (await clientQueryRepository.ExistsAsync(code))
            throw new ClientDomainException("Client already exists");

        return new Client(
            code,
            name,
            entityType,
            dateInception,
            dateTermination,
            terminationReason,
            email,
            phone,
            idTeam,
            address);
    }

    public void Update(
        string? name,
        string? entityType,
        DateTime? dateInception,
        DateTime? dateTermination,
        string? terminationReason,
        string? email,
        string? phone,
        int idTeam,
        Address? address)
    {
        Name = name;
        EntityType = entityType;
        DateInception = dateInception;
        DateTermination = dateTermination;
        TerminationReason = terminationReason;
        Email = email;
        Phone = phone;
        IdTeam = idTeam;
        Address = address;
        AddDomainEvent(new ClientUpdatedDomainEvent());
    }
}