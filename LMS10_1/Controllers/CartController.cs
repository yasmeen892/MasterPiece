using System.Linq;
using Microsoft.AspNetCore.Mvc;
using LMS10_1.Data;
using LMS10_1.Models;
using Microsoft.EntityFrameworkCore;

namespace LMS10_1.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }

        // عرض محتويات السلة
        public IActionResult Index()
        {
            var cartItems = GetCartItems();
            return View(cartItems);
        }

        // إضافة دورة إلى السلة
        [HttpGet, HttpPost]
        public IActionResult AddToCart(int courseId)
        {
            var course = _context.Courses.FirstOrDefault(c => c.CoursesId == courseId);
            if (course == null)
                return NotFound();

            // تحقق إذا كان العنصر موجودًا في السلة
            var cartItem = _context.CartItems.FirstOrDefault(c => c.CoursesId == courseId);
            if (cartItem != null)
            {
                // زيادة الكمية إذا كانت الدورة موجودة مسبقًا في السلة
                cartItem.Quantity++;
            }
            else
            {
                // إضافة الدورة إلى السلة إذا لم تكن موجودة
                _context.CartItems.Add(new CartItem
                {
                    CoursesId = courseId,
                    Quantity = 1
                });
            }

            // حفظ التغييرات في قاعدة البيانات
            _context.SaveChanges();

            // إعادة التوجيه إلى صفحة السلة بعد إضافة الدورة
            return RedirectToAction("Index");
        }

        // حذف عنصر من السلة
        [HttpPost]
        public IActionResult RemoveFromCart(int Id)
        {
            var cartItem = _context.CartItems.FirstOrDefault(c => c.Id == Id);
            if (cartItem == null)
                return NotFound();

            _context.CartItems.Remove(cartItem);
            _context.SaveChanges();

            // إعادة التوجيه إلى صفحة السلة بعد حذف العنصر
            return RedirectToAction("Index");
        }

        // تحديث الكمية في السلة
        [HttpPost]
        public IActionResult UpdateQuantity(int cartItemId, int quantity)
        {
            var cartItem = _context.CartItems.FirstOrDefault(c => c.Id == cartItemId);
            if (cartItem == null)
                return NotFound();

            // إذا كانت الكمية أكبر من 0، قم بتحديث الكمية
            if (quantity > 0)
            {
                cartItem.Quantity = quantity;
                _context.SaveChanges();
            }
            else
            {
                // إذا كانت الكمية أقل من أو تساوي 0، قم بحذف العنصر
                _context.CartItems.Remove(cartItem);
                _context.SaveChanges();
            }

            // إعادة التوجيه إلى صفحة السلة بعد التحديث
            return RedirectToAction("Index");
        }

        // الحصول على عناصر السلة
        private List<CartItem> GetCartItems()
        {
            return _context.CartItems.Include(c => c.Courses).ToList();
        }

        // إجراء الدفع (يمكنك إضافة المنطق الخاص بالدفع هنا)
        public IActionResult Checkout()
        {
            var cartItems = GetCartItems();

            // تحقق من السلة إذا كانت فارغة
            if (!cartItems.Any())
                return RedirectToAction("Index");

            // هنا يمكنك إضافة منطق الدفع، مثل دفع باستخدام PayPal أو البطاقات الائتمانية

            // إعادة توجيه بعد إتمام عملية الدفع (مثال على redirect إلى صفحة الدفع)
            return View(cartItems);
        }
    }
}
