using System.ComponentModel.DataAnnotations;

namespace Application.Validators;

public class AllowedValuesFromProperties(Type type) : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        if (value == null || value is not string)
        {
            return base.IsValid(value);
        }

        return type.GetProperties()
            .Select(x => x.Name)
            .Where(x => x.Equals((string)value, StringComparison.CurrentCultureIgnoreCase))
            .Any();
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var memberNames = validationContext.MemberName is not null
            ? new[] { validationContext.MemberName }
            : null;

        return IsValid(value)
            ? ValidationResult.Success
            : new ValidationResult($"Type '{type.Name}' does not contain '{value}'", memberNames);
    }
}
