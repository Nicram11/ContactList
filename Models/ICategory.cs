
namespace ContactList.Models
{
    //implementation of this interface is required to perform subcategory valdation
    public interface ICategory
    {
        string Category { get; set; }
        string? Subcategory { get; set; }
    }
}
