using ContactApi.Model;
using ContactApi.Service;
using Microsoft.AspNetCore.Mvc;

namespace ContactApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpPost]
        [Route("addcontact")]
        public async Task<int> addcontact([FromBody] Contact contact)
        {
            return await _contactService.AddContact(contact);
        }

        [HttpDelete]
        [Route("deletecontact")]
        public async Task<int> DeleteContact([FromQuery] int contactId)
        {
            return await (_contactService.DeleteContact(contactId));
        }

        [HttpGet]
        [Route("getcontactbyid")]
        public async Task<Contact> GetContactById([FromQuery] int id)
        {
            return await _contactService.GetContactById(id);
        }

        [HttpGet]
        [Route("getcontacts")]
        public async Task<IEnumerable<Contact>> GetContacts()
        {
            return await _contactService.GetContacts();
        }

        [HttpPut]
        [Route("updatecontact")]
        public async Task<int> UpdateContact([FromBody] Contact contact)
        {
            return await _contactService.UpdateContact(contact);
        }
    }
}
