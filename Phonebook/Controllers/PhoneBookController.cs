using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Phonebook.Data;
using Phonebook.Models;

namespace Phonebook.Controllers
{
    public class PhoneBookController : Controller
    {
        private readonly PhonebookContext _context;

        public PhoneBookController(PhonebookContext context)
        {
            _context = context;
        }

        // GET: PhoneBook
        public async Task<IActionResult> Index(string searchString)
        {
            var phoneBooks = from m in _context.PhoneBook
                             select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                phoneBooks = phoneBooks.Where(s => s.Name.Contains(searchString));
            }

            ViewData["PhoneBookList"] = await phoneBooks.ToListAsync();
            //return View(await _context.PhoneBook.ToListAsync());
            return View();
        }

        // GET: PhoneBook/Details/5
        public async Task<IActionResult> Details(int? id, string searchString)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phoneBook = await _context.PhoneBook
                .FirstOrDefaultAsync(m => m.ID == id);

            var phoneBookEntries = from e in _context.PhoneBookEntry
                                   where e.PhonebookID == id
                                   select e; //_context.PhoneBookEntry.Where(x => x.PhonebookID == id);
            if (!String.IsNullOrEmpty(searchString))
            {
                phoneBookEntries = phoneBookEntries.Where(s => s.Name.Contains(searchString));
            }

            if (phoneBook == null)
            {
                return NotFound();
            }

            if(phoneBookEntries.Any())
            {
                ViewBag.PhoneBookEntries = phoneBookEntries.ToList();
            }
            ViewBag.PhoneBook = phoneBook;
            return View();
        }

        // GET: PhoneBook/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PhoneBook/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] PhoneBook phoneBook)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phoneBook);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(phoneBook);
        }

        // GET: PhoneBook/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phoneBook = await _context.PhoneBook.FindAsync(id);
            if (phoneBook == null)
            {
                return NotFound();
            }
            return View(phoneBook);
        }

        // POST: PhoneBook/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name")] PhoneBook phoneBook)
        {
            if (id != phoneBook.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phoneBook);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhoneBookExists(phoneBook.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(phoneBook);
        }

        // GET: PhoneBook/AddEntry/5
        public async Task<IActionResult> AddEntry(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phoneBook = await _context.PhoneBook.FindAsync(id);
            if (phoneBook == null)
            {
                return NotFound();
            }
            ViewBag.PhoneBook = phoneBook;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEntry(int id, [Bind("Name,Number,PhonebookID")] PhonebookEntry phoneBookEntry)
        {

            if (ModelState.IsValid)
            {
                _context.Add(phoneBookEntry);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
        // GET: PhoneBook/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phoneBook = await _context.PhoneBook
                .FirstOrDefaultAsync(m => m.ID == id);
            if (phoneBook == null)
            {
                return NotFound();
            }

            return View(phoneBook);
        }

        // POST: PhoneBook/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var phoneBook = await _context.PhoneBook.FindAsync(id);
            _context.PhoneBook.Remove(phoneBook);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhoneBookExists(int id)
        {
            return _context.PhoneBook.Any(e => e.ID == id);
        }
    }
}
