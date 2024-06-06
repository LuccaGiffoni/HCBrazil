using System.ComponentModel.DataAnnotations.Schema;

namespace HCBrazil.Core.Models;

public class Attendee
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid GuardianId { get; set; }

    [ForeignKey("GuardianId")]
    public Guardian Guardian { get; set; } = null!;
    
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string? Instagram { get; set; }
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