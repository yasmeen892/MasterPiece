using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LMS10_1.Data;
using LMS10_1.Models;
using Microsoft.AspNetCore.Identity;
using LMS10_1.Models.ViewModels;
using Microsoft.AspNetCore.Http;

namespace LMS10_1.Controllers
{
    public class TeacherRequestsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IWebHostEnvironment _webHostEnvironment; 

        public TeacherRequestsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _userManager = userManager;
            _webHostEnvironment = webHostEnvironment;
        }


        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName");
            return View();
        }

      
        [HttpPost]
        public async Task<IActionResult> Create(TeacherRequests model, IFormFile CvFilePath, IFormFile ImageFilePath)
        {
            if (ModelState.IsValid)
            {
          
                var user = await _userManager.GetUserAsync(User);

                if (user == null)
                {
                    TempData["Message"] = "";
                    return RedirectToAction("Login", "Account");
                }

                model.UserId = user.Id;
                model.Status = "Pending";
                model.RequestDate = DateTime.Now;

                
                if (CvFilePath != null)
                {
                    string cvFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads/cvs");
                    Directory.CreateDirectory(cvFolder); 
                    string cvFileName = Guid.NewGuid().ToString() + "_" + CvFilePath.FileName;
                    string cvPath = Path.Combine(cvFolder, cvFileName);

                    using (var fileStream = new FileStream(cvPath, FileMode.Create))
                    {
                        await CvFilePath.CopyToAsync(fileStream);
                    }

                    model.CvFilePath = "/uploads/cvs/" + cvFileName;
                }

                if (ImageFilePath != null)
                {
                    string imageFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads/images");
                    Directory.CreateDirectory(imageFolder); 
                    string imageFileName = Guid.NewGuid().ToString() + "_" + ImageFilePath.FileName;
                    string imagePath = Path.Combine(imageFolder, imageFileName);

                    using (var fileStream = new FileStream(imagePath, FileMode.Create))
                    {
                        await ImageFilePath.CopyToAsync(fileStream);
                    }

                    model.ImageFilePath = "/uploads/images/" + imageFileName;
                }

             
                _context.TeacherRequestss.Add(model);
                await _context.SaveChangesAsync();

                TempData["Message"] = "The Messge reqeaset sent sucssfuly";
                return RedirectToAction("Index", "Home");
            }

            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", model.CategoryId);
            return View(model);
        }

        public IActionResult AdminRequests()
        {
            var requests = _context.TeacherRequestss
                .Include(r => r.User)
                .Include(r => r.Category)
                .ToList();
            return View(requests);
        }


        public async Task<IActionResult> ChangeStatus(int id, string status)
        {
            var request = await _context.TeacherRequestss.FindAsync(id);
            if (request != null)
            {
                request.Status = status;
                _context.Update(request);
                await _context.SaveChangesAsync();

                var user = await _userManager.FindByIdAsync(request.UserId);

                if (status == "Approved")
                {
                    await _userManager.AddToRoleAsync(user, "Teacher");
                    TempData["Message"] = " Approved";
                }
                else if (status == "Rejected")
                {
                    TempData["Message"] = "Rejected";
                }

                return RedirectToAction("TeacherRequests");
            }
            return NotFound();
        }
    }
}
