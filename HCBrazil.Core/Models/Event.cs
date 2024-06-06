namespace HCBrazil.Core.Models;

public class Event
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
}