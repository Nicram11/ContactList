

using ContactList.Models;
using ContactList.Services;

namespace ContactList.Data
{

    public class DataSeeder 
    {
  
        public static async void Seed(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ContactsDbContext>();
                var contactService = scope.ServiceProvider.GetRequiredService<ContactService>();

                if (!dbContext.Users.Any())
                {
                    var user = new Contact
                    {
                        UserName = "admin",
                        FirstName = "admin",
                        LastName = "admin",
                        PhoneNumber = "555654754",
                        Email = "admin@gmail.com",
                        Category = "służbowy",
                        Subcategory = "szef"
                    };
                    await contactService.CreateAsync(user, "Admin123-");
                }
            }

        }
    }
}
