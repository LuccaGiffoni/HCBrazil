using Flunt.Extensions.Br.Validations;
using Flunt.Validations;

namespace HCBrazil.Core.Requests.Attendees
{
    public class CreateAttendeeWithExistingGuardianRequest : Request
    {
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
        public Guid GuardianId { get; set; }
    }
}