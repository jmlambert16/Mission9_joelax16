using Microsoft.AspNetCore.Mvc;
using Mission9.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9.Controllers
{
    public class CheckoutController : Controller

    {
        private ICheckoutRepository repo { get; set; }
        public Basket basket { get; set; }
        public CheckoutController(ICheckoutRepository temp, Basket b)
        {
            repo = temp;
            basket = b;
        }

        [HttpGet]
        public IActionResult FinalCheckout()
        {
            return View(new Checkout());
        }

        [HttpPost]
        public IActionResult FinalCheckout(Checkout checkout)
        {
            if (basket.Items.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your basket is empty!");
            }

            if (ModelState.IsValid)
            {
                checkout.Lines = basket.Items.ToArray();
                repo.SaveCheckout(checkout);
                basket.ClearBasket();

                return RedirectToPage("/Confirm");
            }

            else
            {
                return View();
            }
        }
    }
}
