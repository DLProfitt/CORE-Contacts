using Microsoft.AspNetCore.Mvc;
using COREContacts.Data;
using COREContacts.Models;
using System;
using System.Collections.Generic;

namespace COREContacts.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;

        public ContactsController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        [HttpPost]
        public IActionResult CreateContact(Contact contact)
        {
            _contactRepository.AddContact(contact);
            return CreatedAtAction(nameof(GetContact), new { id = contact.ID }, contact);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateContact(int id, Contact contact)
        {
            _contactRepository.UpdateContact(contact);
            return NoContent();
        }

        [HttpGet]
        public ActionResult<List<Contact>> GetContacts()
        {
            return Ok(_contactRepository.GetContacts());
        }

        [HttpGet("{id}")]
        public ActionResult<Contact> GetContact(int id)
        {
            var contact = _contactRepository.GetContact(id);
            if (contact == null)
            {
                return NotFound();
            }

            return Ok(contact);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteContact(int id)
        {
            _contactRepository.DeleteContact(id);
            return NoContent();
        }
    }
}
