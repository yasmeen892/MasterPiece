
using LMS10_1.Data;
using LMS10_1.Models;
using LMS10_1.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;

namespace LMS10_1.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext ApplicationDbContext;
        public HomeController(ApplicationDbContext _ApplicationDbContext)
        {

            ApplicationDbContext = _ApplicationDbContext;
        }

        public IActionResult Index()
        {
            CategoryCourseDataModel model = new CategoryCourseDataModel
            {
                Courses = ApplicationDbContext.Courses.OrderByDescending(x => x.CoursesId).ToList(),
                Categories = ApplicationDbContext.Categories.OrderByDescending(x => x.CategoryId).ToList()
            };
            return View(model);
        }

        public IActionResult CDetails(int? id)
        {
            if (id == null) { return RedirectToAction("Index"); }

            var data = ApplicationDbContext.Courses
                          .Include(c => c.Category) // Ensure Category is loaded with the Course
                          .FirstOrDefault(c => c.CoursesId == id);

            if (data == null) { return RedirectToAction("Index"); }

            return View(data);
        }

        public IActionResult ArticleDetailes(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var data = ApplicationDbContext.Articles.Find(id);
            if (data == null)
            {
                return RedirectToAction("Index");
            }

            return View(data);
        }





        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
