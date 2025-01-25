using LMS10_1.Data;
using LMS10_1.Models;
using LMS10_1.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LMS10_1.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        // عرض صفحة التسجيل
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // تنفيذ عملية التسجيل
        [HttpPost]
        public async Task<IActionResult> Register(RegisterView model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Gender = model.Gender,
                    UserName = model.Email,
                };

                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "User"); // تعيين الدور الافتراضي للمستخدم
                    return RedirectToAction("Login");
                }

                foreach (var err in result.Errors)
                {
                    ModelState.AddModelError("", err.Description);
                }
            }
            return View(model);
        }

        // عرض صفحة تسجيل الدخول
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // تنفيذ عملية تسجيل الدخول
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user.UserName, model.Password, model.RememberMe, false);
                    if (result.Succeeded)
                    {
                        var roles = await _userManager.GetRolesAsync(user);

                        // التحقق من الدور وإعادة التوجيه إلى الصفحة المناسبة
                        if (roles.Contains("Admin"))
                        {
                            return RedirectToAction("Index", "Home", new { area = "Admin" });
                        }
                        else if (roles.Contains("Teacher"))
                        {
                            return RedirectToAction("Index", "Home", new { area = "Teacher" });
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home", new { area = "default" });
                        }
                    }
                }

                ModelState.AddModelError("", "Invalid email or password");
            }

            return View(model);
        }

        // تسجيل الخروج
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }

   
    }
}
