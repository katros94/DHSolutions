using Microsoft.EntityFrameworkCore;
using Phonebook.Data;

namespace Phonebook.Data
{
    public class PhonebookDbContext : DbContext
    {
        public PhonebookDbContext(DbContextOptions<PhonebookDbContext> options) : base(options)
        {
        }

        public DbSet<Contact> Contact { get; set; }

    }
}
