using System.ComponentModel.DataAnnotations;

namespace Application.TaskManager.CustomValidationAttributes;

[AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
internal class DateNotInPastAttribute : ValidationAttribute
{
	protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
	{
		if (value is DateTime date && date < DateTime.Today)
			return new ValidationResult($"{validationContext.DisplayName} cannot be in the past.");

		return ValidationResult.Success;
	}
}
