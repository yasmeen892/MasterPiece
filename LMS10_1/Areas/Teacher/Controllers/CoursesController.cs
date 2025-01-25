using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LMS10_1.Data;
using LMS10_1.Models;
using Microsoft.AspNetCore.Authorization;

namespace LMS10_1.Areas.Teacher.Controllers
{
    [Area("Teacher")]
    [Authorize(Roles = "Teacher")]
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CoursesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Teacher/Courses
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Courses.Include(c => c.Category);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Teacher/Courses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courses = await _context.Courses
                .Include(c => c.Category)
                .FirstOrDefaultAsync(m => m.CoursesId == id);
            if (courses == null)
            {
                return NotFound();
            }

            return View(courses);
        }

        // GET: Teacher/Courses/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId");
            return View();
        }

        // POST: Teacher/Courses/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Courses courses)
        {
          
            if (ModelState.IsValid)
            {
                var teacherIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

                // Convert the string teacherIdClaim to an integer
                if (int.TryParse(teacherIdClaim, out int teacherId))
                {
                    courses.TeacherId = teacherId; // Assuming TeacherId is an int in the Courses model
                }
                else
                {
                    return BadRequest("Invalid teacher ID."); // Handle the error appropriately
                }

                if (courses.ImageFile != null)
                {
                    // حفظ الصورة
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", courses.ImageFile.FileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await courses.ImageFile.CopyToAsync(stream);
                    }
                    courses.ImagePath = "/images/" + courses.ImageFile.FileName; // تخزين المسار النسبي
                }

                _context.Add(courses);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", courses.CategoryId);
            return View(courses);
        }

        // GET: Teacher/Courses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courses = await _context.Courses.FindAsync(id);
            if (courses == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", courses.CategoryId);
            return View(courses);
        }

        // POST: Teacher/Courses/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,  Courses courses)
        {
            if (id != courses.CoursesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (courses.ImageFile != null)
                    {
                        // حفظ الصورة الجديدة
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", courses.ImageFile.FileName);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await courses.ImageFile.CopyToAsync(stream);
                        }
                        courses.ImagePath = "/images/" + courses.ImageFile.FileName;
                    }

                    _context.Update(courses);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CoursesExists(courses.CoursesId))
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
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", courses.CategoryId);
            return View(courses);
        }

        // GET: Teacher/Courses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courses = await _context.Courses
                .Include(c => c.Category)
                .FirstOrDefaultAsync(m => m.CoursesId == id);
            if (courses == null)
            {
                return NotFound();
            }

            return View(courses);
        }

        // POST: Teacher/Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var courses = await _context.Courses.FindAsync(id);
            if (courses != null)
            {
                _context.Courses.Remove(courses);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CoursesExists(int id)
        {
            return _context.Courses.Any(e => e.CoursesId == id);
        }
    }
}
