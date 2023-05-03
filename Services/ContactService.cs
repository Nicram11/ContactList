

using ContactList.Data;
using ContactList.DTOs;
using ContactList.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace ContactList.Services
{
 
    public class ContactService : UserManager<Contact>
    {
        private readonly UserStore<Contact, IdentityRole, ContactsDbContext, string, IdentityUserClaim<string>,
        IdentityUserRole<string>, IdentityUserLogin<string>, IdentityUserToken<string>, IdentityRoleClaim<string>>
        store;


        public ContactService(
            IUserStore<Contact> store,
            IOptions<IdentityOptions> optionsAccessor,
            IPasswordHasher<Contact> passwordHasher,
            IEnumerable<IUserValidator<Contact>> userValidators,
            IEnumerable<IPasswordValidator<Contact>> passwordValidators,
            ILookupNormalizer keyNormalizer,
            IdentityErrorDescriber errors,
            IServiceProvider services,
            ILogger<UserManager<Contact>> logger) : base(store, optionsAccessor, passwordHasher, userValidators, 
                passwordValidators, keyNormalizer, errors, services, logger)
        {
            this.store = (UserStore<Contact, IdentityRole, ContactsDbContext, string, IdentityUserClaim<string>,
           IdentityUserRole<string>, IdentityUserLogin<string>, IdentityUserToken<string>, IdentityRoleClaim<string>>)store;

        }

        public async Task<IEnumerable<Contact>> GetAllAsync()
        {
            return await store.Users.ToListAsync();
        }

        public async Task<IdentityResult> DeleteByIdAsync(string id)
        {
            var contact = await FindByIdAsync(id);
            if (contact == null) return IdentityResult.Failed();
           return await DeleteAsync(contact);

        }
      

    }
}
