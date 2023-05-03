using ContactList.Models;
using ContactList.Models.Validators;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ContactList.DTOs
{
    public class CreateContactRequest : ICategory
    {  

        public string UserName { get; set; }
        public string Password { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        [CategoryValidation]
        public string Category { get; set; }
        [SubcategoryValidation]
        public string? Subcategory { get; set; }

    }
}
