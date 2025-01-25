using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LMS10_1.Data;
using LMS10_1.Models;

namespace LMS10_1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactUsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContactUsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/ContactUs
        public async Task<IActionResult> Index()
        {
            return View(await _context.contactUs.ToListAsync());
        }

        // GET: Admin/ContactUs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactUs = await _context.contactUs
                .FirstOrDefaultAsync(m => m.ContactUsId == id);
            if (contactUs == null)
            {
                return NotFound();
            }

            return View(contactUs);
        }

   

        // GET: Admin/ContactUs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactUs = await _context.contactUs
                .FirstOrDefaultAsync(m => m.ContactUsId == id);
            if (contactUs == null)
            {
                return NotFound();
            }

            return View(contactUs);
        }

        // POST: Admin/ContactUs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contactUs = await _context.contactUs.FindAsync(id);
            if (contactUs != null)
            {
                _context.contactUs.Remove(contactUs);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactUsExists(int id)
        {
            return _context.contactUs.Any(e => e.ContactUsId == id);
        }
    }
}
