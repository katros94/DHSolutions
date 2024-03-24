using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Phonebook.Data;
using Phonebook.Models;
using Contact = Phonebook.Models.Contact;

namespace Phonebook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly PhonebookDbContext _context;

        public ContactsController(PhonebookDbContext context)
        {
            _context = context;
        }

        // GET: api/Contact
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contact>>> GetContact()
        {
          if (_context.Contact == null)
          {
              return NotFound();
          }

            var contactModelList = new List<Contact>();
            var contactDataList = await _context.Contact.ToListAsync();

            contactDataList.ForEach(c => {
                var contactModel = new Phonebook.Models.Contact()
                {
                    Id = c.Id,
                    Name = c.Name,
                    Phonenumber = c.Phonenumber
                };
                contactModelList.Add(contactModel);
            });



            return contactModelList;
        }

        // POST: api/Contact
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Contact>> PostContact(Contact contact)
        {
            if (_context.Contact == null)
            {
                return Problem("Entity set 'PhonebookDbContext.Contact'  is null.");
            }

            var contactData = new Phonebook.Data.Contact() 
            { 
                Name = contact.Name, 
                Phonenumber = contact.Phonenumber 
            };

            _context.Contact.Add(contactData);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContact", new { id = contact.Id }, contact);
        }

        private bool ContactExists(int id)
        {
            return (_context.Contact?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
