using ContactList.Models.Validators;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ContactList.Models
{
    public class Contact : IdentityUser, ICategory
    {
        //properties such as id, email, password, phone number are inherited from the IdentityUSer class

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        [Required]
        [CategoryValidation]
        public string Category { get; set; }
        [SubcategoryValidation]
        public string? Subcategory { get; set; }

    }
}
