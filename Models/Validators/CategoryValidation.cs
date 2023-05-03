using System.ComponentModel.DataAnnotations;

namespace ContactList.Models.Validators
{
    public class CategoryValidation : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var allowedCategories = new[] { "służbowy", "prywatny", "inny" };

            if (value == null || !allowedCategories.Contains(value.ToString()))
            {
                return new ValidationResult($"Pole 'Category' może przyjmować tylko wartości: {string.Join(", ", allowedCategories)}.");
            }

            return ValidationResult.Success;
        }
    }
}
