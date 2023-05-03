using ContactList.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ContactList.Data
{
    public class ContactsDbContext : IdentityDbContext<Contact>
    {
        public ContactsDbContext(DbContextOptions<ContactsDbContext> options)
        : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Contact>().Property(m => m.Subcategory).IsRequired(false);

            base.OnModelCreating(builder);
        }
    
    }
}
