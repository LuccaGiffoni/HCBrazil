﻿namespace HCBrazil.Core.Requests.Attendees
{
    public class CreateAttendeeRequest : Request
    {
        public Guid OrganizationId { get; set; }

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
        
        public string GuardianFirstName { get; set; } = null!;
        public string GuardianLastName { get; set; } = null!;
        public string GuardianPhone { get; set; } = null!;
        public string GuardianEmail { get; set; } = null!;
        public string? GuardianRG { get; set; }
        public string GuardianCPF { get; set; } = null!;
        public string GuardianCountry { get; set; } = null!;
        public string GuardianState { get; set; } = null!;
        public string GuardianCity { get; set; } = null!;
        public string GuardianStreet { get; set; } = null!;
        public string GuardianRegion { get; set; } = null!;
        public int GuardianPostalCode { get; set; }
        public int GuardianNumber { get; set; }
    }
}