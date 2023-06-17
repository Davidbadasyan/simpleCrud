namespace simpleCrud.Domain.Exceptions;

public class ClientDomainException : DomainException
{
    public ClientDomainException()
    { }

    public ClientDomainException(string message)
        : base(message)
    { }

    public ClientDomainException(string message, Exception innerException)
        : base(message, innerException)
    { }
}