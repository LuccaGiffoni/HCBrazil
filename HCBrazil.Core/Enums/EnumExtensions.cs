using System.ComponentModel.DataAnnotations;

namespace HCBrazil.Core.Enums;

public static class EnumExtensions
{
    public static string GetDisplayName<TEnum>(this TEnum value)
        where TEnum : Enum
    {
        var displayNameAttribute = value.GetType()
            .GetField(value.ToString())
            ?.GetCustomAttributes(typeof(DisplayAttribute), false)
            .OfType<DisplayAttribute>()
            .FirstOrDefault();

        return displayNameAttribute?.Name ?? value.ToString();
    }
}
