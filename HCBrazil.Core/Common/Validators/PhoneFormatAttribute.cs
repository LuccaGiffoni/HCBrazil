using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace HCBrazil.Core.Common.Validators;

public partial class PhoneFormatAttribute : ValidationAttribute
{
    [GeneratedRegex(@"^\+\d{2} \d{2} \d{5}-\d{4}$")] private static partial Regex PhoneRegex();

    public override bool IsValid(object? value)
    {
        if (value is not string phoneNumber) return false;
        
        var regex = PhoneRegex();
        return regex.IsMatch(phoneNumber);
    }

    public override string FormatErrorMessage(string name)
    {
        return $"The {name} field is not in the correct format. It should be in the format +XX XX XXXXX-XXXX.";
    }
}