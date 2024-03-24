using System.ComponentModel.DataAnnotations;

namespace Phonebook.Data
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Phonenumber { get; set; }
    }
}


