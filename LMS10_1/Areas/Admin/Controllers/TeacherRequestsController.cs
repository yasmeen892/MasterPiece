using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LMS10_1.Data;
using LMS10_1.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using LMS10_1.Models.ViewModels;
using LMS10_1.Models;


namespace LMS10_1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TeacherRequestsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public TeacherRequestsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // عرض الطلبات حسب الحالة


        public IActionResult Index(int page = 1, int pageSize = 9)
        {
            // إجمالي عدد السجلات لكل حالة
            var totalPosts = _context.TeacherRequestss.Count(r => r.Status == "Pending");

            // حساب إجمالي الصفحات
            var totalPages = (int)Math.Ceiling((double)totalPosts / pageSize);

            // جلب السجلات الخاصة بالصفحة المطلوبة (حالة قيد الانتظار فقط كمثال)
            var pendingRequests = _context.TeacherRequestss
                .Include(r => r.User)
                .Include(r => r.Category)
                .Where(r => r.Status == "Pending")
                .Skip((page - 1) * pageSize) // تخطي السجلات السابقة
                .Take(pageSize) // عدد السجلات المطلوبة
                .ToList();

            var approvedRequests = _context.TeacherRequestss
                .Include(r => r.User)
                .Include(r => r.Category)
                .Where(r => r.Status == "Approved")
                .ToList();

            var rejectedRequests = _context.TeacherRequestss
                .Include(r => r.User)
                .Include(r => r.Category)
                .Where(r => r.Status == "Rejected")
                .ToList();

            // إرسال البيانات إلى View
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;
            ViewBag.PendingRequests = pendingRequests;
            ViewBag.ApprovedRequests = approvedRequests;
            ViewBag.RejectedRequests = rejectedRequests;

            return View(pendingRequests);
        }



        // عرض تفاصيل الطلب
        public async Task<IActionResult> Details(int id)
        {
            var request = await _context.TeacherRequestss
                .Include(r => r.User)
                .Include(r => r.Category)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (request == null)
            {
                return NotFound();
            }

            return View(request);
        }

        // تغيير الحالة
        [HttpPost]
        public async Task<IActionResult> ChangeStatus(int id, string status)
        {
            var request = await _context.TeacherRequestss.FindAsync(id);

            if (request == null)
            {
                return NotFound();
            }

            request.Status = status;
            _context.Update(request);
            await _context.SaveChangesAsync();

            // تحويل الطلب إلى معلم عند الموافقة
            if (status == "Approved")
            {
                var user = await _userManager.FindByIdAsync(request.UserId);
                if (user != null)
                {
                    await _userManager.AddToRoleAsync(user, "Teacher");
                }


                var teacher = new Models.Teacher
                {
                UserId = user.Id,  // تأكد من أن هذا هو معرّف المستخدم
                Name = user.UserName,  // أو أي بيانات أخرى تريد إضافتها
                CategoryId = request.CategoryId,  // الفئة المعينة من الطلب
                Email = user.Email,  // البريد الإلكتروني
                CvFilePath=request.CvFilePath,
                ImageFilePath=request.ImageFilePath,// إذا كنت بحاجة لإضافة البريد الإلكتروني
                                         // يمكنك إضافة بيانات أخرى حسب الحاجة
                };

                _context.Teachers.Add(teacher); // إضافة السجل إلى جدول المعلمين
                await _context.SaveChangesAsync();
            }
        

        TempData["Message"] = $"Status changed to {status}";
            return RedirectToAction(nameof(Index));
        }

        // حذف الطلب
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var request = await _context.TeacherRequestss.FindAsync(id);

            if (request == null)
            {
                return NotFound();
            }

            _context.TeacherRequestss.Remove(request);
            await _context.SaveChangesAsync();

            TempData["Message"] = "Request deleted successfully.";
            return RedirectToAction(nameof(Index));
        }
    }
}
