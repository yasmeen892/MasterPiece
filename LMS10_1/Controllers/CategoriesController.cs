using LMS10_1.Data;
using LMS10_1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LMS10_1.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // عرض جميع الفئات
        public async Task<IActionResult> Index()
        {
            var categories = await _context.Categories.ToListAsync();
            return View(categories);
        }

        // عرض الدورات الخاصة بفئة معينة
        public async Task<IActionResult> CoursesByCategoryId(int id)
        {
            // جلب الفئة مع الدورات الخاصة بها
            var category = await _context.Categories
                .Include(c => c.Courses)  // تضمين الدورات المرتبطة بالفئة
                .FirstOrDefaultAsync(c => c.CategoryId == id);

            // إذا لم يتم العثور على الفئة
            if (category == null)
            {
                return NotFound();
            }

            // تمرير الفئة مع الدورات إلى الـView
            return View(category);  // سيتم عرض الـView CoursesByCategoryId.cshtml في مجلد Categories
        }
    }
}
