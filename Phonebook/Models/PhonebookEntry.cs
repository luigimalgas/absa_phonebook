using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phonebook.Models
{
    public class PhonebookEntry
    {
        public int ID { get; set; }
        public int PhonebookID { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
    }
}
