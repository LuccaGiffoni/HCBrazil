using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCBrazil.Core.Models;

public class EventVolunteers
{
    [Key, Column(Order = 0)]
    public Guid EventId { get; set; }

    [Key, Column(Order = 1)]
    public Guid VolunteerId { get; set; }

    public Event Event { get; set; } = null!;
    public Volunteer Volunteer { get; set; } = null!;
}