using AutoMapper;
using ContactList.DTOs;
using ContactList.Models;
using ContactList.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContactList.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class ContactsController : ControllerBase
    {
        private readonly ContactService contactService;
        private readonly IMapper mapper;

        public ContactsController(ContactService contactService, IMapper mapper)
        {
            this.contactService = contactService;
            this.mapper = mapper;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            if (id is null)
                return BadRequest("id nie może być puste");


            var result =mapper.Map<GetContactResult>(await contactService.FindByIdAsync(id));
            if(result is null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = mapper.Map<IEnumerable<Contact>, List<GetContactResult>>(await contactService.GetAllAsync());
            if (result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateContactRequest contactDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var contact = mapper.Map<Contact>(contactDto);
         
            var result =await contactService.CreateAsync(contact, contactDto.Password);
            if (result.Succeeded)
                return Created(nameof(GetAll), null);
            
            return BadRequest(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            var result = await contactService.DeleteByIdAsync(id);
            if (result.Succeeded)
                return Accepted();

            return NotFound(result);
        }


    }
}
