using AutoMapper;
using ContactList.DTOs;
using ContactList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactList.MappingProfiles
{
    public class ContactMapper : Profile
    {
        public ContactMapper()
        {
            CreateMap<CreateContactRequest,Contact>();
            CreateMap<Contact, GetContactResult>();
        }
       
    }
}
