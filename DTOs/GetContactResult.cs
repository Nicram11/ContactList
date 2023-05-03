
using ContactList.Models;

namespace ContactList.DTOs
{ 
    public class GetContactResult : ICategory
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Category { get; set; }
        public string Subcategory { get; set; }
    }
}
