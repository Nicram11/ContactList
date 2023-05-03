using System.ComponentModel.DataAnnotations;

namespace ContactList.Models.Validators
{
    public class SubcategoryValidation : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var contact = (ICategory)validationContext.ObjectInstance;

            if (contact == null)
            {
                return new ValidationResult("Obiekt nie jest typu IContact");
            }

            if (contact.Category == "służbowy" && (contact.Subcategory == null || !new[] { "szef", "klient", "pracownik" }.Contains(contact.Subcategory)))
            {
                return new ValidationResult("Dla kategorii [służbowy] możliwe podkategorie to: [szef], [klient], [pracownik]");
            }

            if (contact.Category == "prywatny" && contact.Subcategory != null)
            {
                return new ValidationResult("Dla kategorii 'prywatny' nie można ustawić podkategorii");
            }

            if (contact.Category == "inny" && string.IsNullOrEmpty(contact.Subcategory))
            {
                return new ValidationResult("Dla kategorii 'inny', podkategoria musi być ustawiona.");
            }

            return ValidationResult.Success;
        }
    }
}
