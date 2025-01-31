using Microsoft.AspNetCore.Mvc;
using ContactM.Models;
using ContactM.Services;

namespace ContactM.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Contact>>> GetAll(int pageNumber, int pageSize)
        {
            var contacts = await _contactService.GetAllAsync(pageNumber,pageSize);
            return Ok(contacts);
        }

        [HttpGet("{id:int}")]
        public ActionResult<Contact> GetByID(int id)
        {
            var contact =  _contactService.GetByIdAsync(id);
            if (contact == null)
            {
                return NotFound($"Contact with ID {id} not found.");
            }
            return Ok(contact);
        }
       
       

        [HttpPost]
        public async Task<ActionResult<Contact>> AddContact([FromBody] Contact newcontact)
        {
            if (newcontact== null)
            {
                return BadRequest("The contact data is empty. Retry!");
            }
            var contact = await _contactService.AddAsync(newcontact);
            return CreatedAtAction(nameof(GetByID), new { id = contact.Id }, contact);
        }

        [HttpPut("{id}")]       public async Task<ActionResult<Contact>> UpdateContact(int id, [FromBody] Contact updatedContact)
        {
            var updated = await _contactService.UpdateAsync(id, updatedContact);
            if (updated == null)
            {
                return NotFound($"Contact with ID {id} not found.");
            }
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteContact(int id)
        {
            var deleted = await _contactService.DeleteAsync(id);
            if (deleted)
            {
                return Ok($"Contact with ID {id} deleted successfully.");
            }
            return NotFound($"Contact with ID {id} not found.");
        }
    }
}
