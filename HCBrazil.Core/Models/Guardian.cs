using HCBrazil.Core.Enums;

namespace HCBrazil.Core.Models;

public class Guardian
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? RG { get; set; }
    public string CPF { get; set; } = null!;
    public string Country { get; set; } = null!;
    public string State { get; set; } = null!;
    public string City { get; set; } = null!;
    public string Street { get; set; } = null!;
    public string Region { get; set; } = null!;
    public int PostalCode { get; set; }
    public int Number { get; set; }
}