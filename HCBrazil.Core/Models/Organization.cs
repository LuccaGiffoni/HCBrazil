using HCBrazil.Core.Enums;

namespace HCBrazil.Core.Models;

public class Organization
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public EOrganizationType OrganizationType { get; set; }
    public string Name { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Country { get; set; } = null!;
    public string State { get; set; } = null!;
    public string City { get; set; } = null!;
    public string Street { get; set; } = null!;
    public string Region { get; set; } = null!;
    public int PostalCode { get; set; }
    public int Number { get; set; }
    public string GuardianFirstName { get; set; } = null!;
    public string GuardianLastName { get; set; } = null!;
    public string GuardianPhone { get; set; } = null!;
    public string GuardianEmail { get; set; } = null!;
}