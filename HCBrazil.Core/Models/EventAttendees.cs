using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCBrazil.Core.Models;

public class EventAttendees
{
    [Key, Column(Order = 0)]
    public Guid EventId { get; set; }

    [Key, Column(Order = 1)]
    public Guid AttendeeId { get; set; }

    public Event Event { get; set; } = null!;
    public Attendee Attendee { get; set; } = null!;
}