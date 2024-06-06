﻿using Flunt.Extensions.Br.Validations;
using Flunt.Validations;

namespace HCBrazil.Core.Requests.Guardians
{
    public abstract class GuardianRequest : Request
    {
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
}