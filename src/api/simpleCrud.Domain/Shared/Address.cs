namespace simpleCrud.Domain.Shared;

public class Address : ValueObject
{
    public string? Address1 { get; private set; }
    public string? Address2 { get; private set; }
    public string? City { get; private set; }
    public string? State { get; private set; }
    public string? ZipCode { get; private set; }

    private Address() { }

    public Address(string address1, string address2, string city, string state, string zipcode)
    {
        Address1 = address1;
        Address2 = address2;
        City = city;
        State = state;
        ZipCode = zipcode;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Address1;
        yield return Address2;
        yield return City;
        yield return State;
        yield return ZipCode;
    }
}