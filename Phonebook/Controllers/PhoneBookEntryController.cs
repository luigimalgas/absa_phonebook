using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Phonebook.Data;

namespace Phonebook.Controllers
{
    public class PhoneBookEntryController : Controller
    {
        private readonly PhonebookContext _context;

        public PhoneBookEntryController(PhonebookContext context)
        {
            _context = context;
        }
        // GET: PhoneBookEntry
        public ActionResult Index()
        {
            return View();
        }

        // GET: PhoneBookEntry/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PhoneBookEntry/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PhoneBookEntry/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PhoneBookEntry/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PhoneBookEntry/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PhoneBookEntry/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phoneBookEntry = await _context.PhoneBookEntry
                .FirstOrDefaultAsync(m => m.ID == id);
            if (phoneBookEntry == null)
            {
                return NotFound();
            }
            return View(phoneBookEntry);
        }

        // POST: PhoneBook/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var phoneBookEntry = await _context.PhoneBookEntry.FindAsync(id);
            _context.PhoneBookEntry.Remove(phoneBookEntry);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), nameof(PhoneBookController));
        }
    }
}
