using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using HCBrazil.Core.Common.Validators;

namespace HCBrazil.Core.Requests.Attendees
{
    public class CreateAttendeeRequest : Request
    {
        [Required(ErrorMessage = "Organization ID is required.")]
        public Guid OrganizationId { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [StringLength(100, ErrorMessage = "First name cannot be longer than 100 characters.")]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(100, ErrorMessage = "Last name cannot be longer than 100 characters.")]
        public string LastName { get; set; } = null!;

        [Required(ErrorMessage = "Phone number is required.")]
        [PhoneFormat]
        public string Phone { get; set; } = null!;

        [StringLength(50, ErrorMessage = "Instagram handle cannot be longer than 50 characters.")]
        public string? Instagram { get; set; }

        [RegularExpression(@"^\d{1,14}$", ErrorMessage = "RG must be numeric and up to 14 digits.")]
        public string? RG { get; set; }

        [Required(ErrorMessage = "CPF is required.")]
        [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}\-\d{2}$", ErrorMessage = "Invalid CPF format. Use XXX.XXX.XXX-XX.")]
        public string CPF { get; set; } = null!;

        [Required(ErrorMessage = "Country is required.")]
        [StringLength(100, ErrorMessage = "Country cannot be longer than 100 characters.")]
        public string Country { get; set; } = null!;

        [Required(ErrorMessage = "State is required.")]
        [StringLength(100, ErrorMessage = "State cannot be longer than 100 characters.")]
        public string State { get; set; } = null!;

        [Required(ErrorMessage = "City is required.")]
        [StringLength(100, ErrorMessage = "City cannot be longer than 100 characters.")]
        public string City { get; set; } = null!;

        [Required(ErrorMessage = "Street is required.")]
        [StringLength(200, ErrorMessage = "Street cannot be longer than 200 characters.")]
        public string Street { get; set; } = null!;

        [Required(ErrorMessage = "Region is required.")]
        [StringLength(100, ErrorMessage = "Region cannot be longer than 100 characters.")]
        public string Region { get; set; } = null!;

        [Required(ErrorMessage = "Postal Code is required.")]
        [RegularExpression(@"^\d{5}\-\d{3}$", ErrorMessage = "Invalid Postal Code format. Use XXXXX-XXX.")]
        public int PostalCode { get; set; }

        [Required(ErrorMessage = "Number is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Number must be a positive integer.")]
        public int Number { get; set; }

        [Required(ErrorMessage = "Guardian's first name is required.")]
        [StringLength(100, ErrorMessage = "Guardian's first name cannot be longer than 100 characters.")]
        public string GuardianFirstName { get; set; } = null!;

        [Required(ErrorMessage = "Guardian's last name is required.")]
        [StringLength(100, ErrorMessage = "Guardian's last name cannot be longer than 100 characters.")]
        public string GuardianLastName { get; set; } = null!;

        [Required(ErrorMessage = "Guardian's phone number is required.")]
        [Phone(ErrorMessage = "Invalid phone number format.")]
        public string GuardianPhone { get; set; } = null!;

        [Required(ErrorMessage = "Guardian's email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        public string GuardianEmail { get; set; } = null!;

        [RegularExpression(@"^\d{1,14}$", ErrorMessage = "Guardian's RG must be numeric and up to 14 digits.")]
        public string? GuardianRG { get; set; }

        [Required(ErrorMessage = "Guardian's CPF is required.")]
        [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}\-\d{2}$", ErrorMessage = "Invalid Guardian's CPF format. Use XXX.XXX.XXX-XX.")]
        public string GuardianCPF { get; set; } = null!;

        [Required(ErrorMessage = "Guardian's country is required.")]
        [StringLength(100, ErrorMessage = "Guardian's country cannot be longer than 100 characters.")]
        public string GuardianCountry { get; set; } = null!;

        [Required(ErrorMessage = "Guardian's state is required.")]
        [StringLength(100, ErrorMessage = "Guardian's state cannot be longer than 100 characters.")]
        public string GuardianState { get; set; } = null!;

        [Required(ErrorMessage = "Guardian's city is required.")]
        [StringLength(100, ErrorMessage = "Guardian's city cannot be longer than 100 characters.")]
        public string GuardianCity { get; set; } = null!;

        [Required(ErrorMessage = "Guardian's street is required.")]
        [StringLength(200, ErrorMessage = "Guardian's street cannot be longer than 200 characters.")]
        public string GuardianStreet { get; set; } = null!;

        [Required(ErrorMessage = "Guardian's region is required.")]
        [StringLength(100, ErrorMessage = "Guardian's region cannot be longer than 100 characters.")]
        public string GuardianRegion { get; set; } = null!;

        [Required(ErrorMessage = "Guardian's postal code is required.")]
        [RegularExpression(@"^\d{5}\-\d{3}$", ErrorMessage = "Invalid Guardian's Postal Code format. Use XXXXX-XXX.")]
        public int GuardianPostalCode { get; set; }

        [Required(ErrorMessage = "Guardian's number is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Guardian's number must be a positive integer.")]
        public int GuardianNumber { get; set; }
    }
}