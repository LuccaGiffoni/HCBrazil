using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCBrazil.Core.Models;

public class EventOrganizations
{
    [Key, Column(Order = 0)]
    public Guid EventId { get; set; }

    [Key, Column(Order = 1)]
    public Guid OrganizationId { get; set; }

    public Event Event { get; set; } = null!;
    public Organization Organization { get; set; } = null!;
}