using Application.DTO;
using Application.Interfaces;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers
{
    public class PaymentController1(IPaymentService paymentServices) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var response = await paymentServices.GetAllPayments();

            if (!response.IsSuccessful)
            {
                TempData["Error"] = response.Message;
                return View(new List<PaymentResponseModel>());
            }

            return View(response.Data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PaymentRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var response = await paymentServices.MakePayment(model);

            if (!response.IsSuccessful)
            {
                ModelState.AddModelError("", response.Message);
                return View(model);
            }

            TempData["Success"] = response.Message;
            return RedirectToAction(nameof(Index));
        }
       
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await paymentServices.GetPayment(id);

            if (!response.IsSuccessful)
            {
                TempData["Error"] = response.Message;
                return RedirectToAction(nameof(Index));
            }

            return View(response.Data);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var response = await paymentServices.DeletePayment(id);

            TempData["Success"] = response.Message;
            return RedirectToAction(nameof(Index));
        }
    }
}

