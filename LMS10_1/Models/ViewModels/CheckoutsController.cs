
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LMS10_1.Data;
using Newtonsoft.Json;
using System;


namespace LMS10_1.Models.ViewModels
{
    public class CheckoutsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CheckoutsController(ApplicationDbContext context)
        {
            _context = context;
        }



        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Checkout()
        {
            var orderIdString = HttpContext.Session.GetString("OrderId");
            if (string.IsNullOrEmpty(orderIdString))
            {
                return RedirectToAction("Index");
            }

            if (!int.TryParse(orderIdString, out int orderId))
            {
                return RedirectToAction("Index");
            }

            var order = _context.Orders.Include(o => o.OrderItems).FirstOrDefault(o => o.OrderId == orderId);
            if (order == null || order.OrderItems == null || !order.OrderItems.Any())
            {
                return RedirectToAction("Index");
            }

            var checkoutModel = new Checkout
            {
                OrderId = orderId,

                OrderItems = order.OrderItems.Select(item => new OrderItem
                {
                    CoursesId = item.CoursesId,
                    Price = item.Price,
                    Quantity = item.Quantity
                }).ToList(),
                Subtotal = order.SubPrice,
                Shipping = 0,
                Total = order.TotalPrice
            };

            // Set the total amount to ViewBag for use in the view
            ViewBag.TotalAmount = checkoutModel.Total;

            return View(checkoutModel);
        }

        [HttpPost]
        public async Task<IActionResult> PlaceOrder(Checkout model)
        {
            if (ModelState.IsValid)
            {
                var order = await _context.Orders.FindAsync(model.OrderId);
                if (order == null) return NotFound();



                await _context.SaveChangesAsync();


                _context.Orders.Update(order);
                await _context.SaveChangesAsync();

                // Set total amount in ViewBag
                ViewBag.TotalAmount = model.Total;

                TempData["CheckoutModel"] = JsonConvert.SerializeObject(model);

                return RedirectToAction("Index", "PayPal");
            }

            return View("Checkout", model);
        }

        public IActionResult OrderConfirmation()
        {
            var checkoutModelJson = TempData["CheckoutModel"] as string;
            var checkoutModel = JsonConvert.DeserializeObject<Checkout>(checkoutModelJson);

            return View(checkoutModel);
        }

        private bool ValidateCheckoutInputs(string senderName, string senderEmail, int senderNumber, string receiverName, string receiverEmail, int receiverNumber, string receiverLocation)
        {
            return !string.IsNullOrWhiteSpace(senderName) &&
                   !string.IsNullOrWhiteSpace(senderEmail) &&
                   senderNumber > 0 &&
                   !string.IsNullOrWhiteSpace(receiverName) &&
                   !string.IsNullOrWhiteSpace(receiverEmail) &&
                   receiverNumber > 0 &&
                   !string.IsNullOrWhiteSpace(receiverLocation);
        }
    }
}
