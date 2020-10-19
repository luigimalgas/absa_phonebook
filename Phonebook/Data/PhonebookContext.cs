using Microsoft.EntityFrameworkCore;
using Phonebook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phonebook.Data
{
    public class PhonebookContext : DbContext
    {
        public PhonebookContext(DbContextOptions<PhonebookContext> options)
            : base(options)
        {
        }

        public DbSet<PhoneBook> PhoneBook { get; set; }
        public DbSet<PhonebookEntry> PhoneBookEntry { get; set; }
    }
}
