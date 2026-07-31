using Application.DTO;
using Application.Interfaces;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers
{
    public class BookingController(IBookingServices bookingServices) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var response = await bookingServices.GetAllBookings();

            if (!response.IsSuccessful)
            {
                TempData["Error"] = response.Message;
                return View(new List<BookingResponseModel>());
            }

            return View(response.Data);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var response = await bookingServices.GetBooking(id);

            if (!response.IsSuccessful)
            {
                TempData["Error"] = response.Message;
                return RedirectToAction(nameof(Index));
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
        public async Task<IActionResult> Create(BookingRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var response = await bookingServices.CreateBooking(model);

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
            var response = await bookingServices.GetBooking(id);

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
            var response = await bookingServices.DeleteBooking(id);

            TempData["Success"] = response.Message;
            return RedirectToAction(nameof(Index));
        }

     

    }
}

   
