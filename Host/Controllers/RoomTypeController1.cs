using Application.DTO;
using Application.Interfaces;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers
{
    public class RoomTypeController1(IRoomTypeService roomTypeServices) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var response = await roomTypeServices.GetAllRoomTypes();

            if (!response.IsSuccessful)
            {
                TempData["Error"] = response.Message;
                return View(new List<RoomTypeResponseModel>());
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
        public async Task<IActionResult> Create(RoomTypeRequestModel request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            var response = await roomTypeServices.AddRoomType(request);

            if (!response.IsSuccessful)
            {
                ModelState.AddModelError("", response.Message);
                return View(request);
            }

            TempData["Success"] = response.Message;
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await roomTypeServices.GetRoomType(id);

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
            var response = await roomTypeServices.DeleteRoomType(id);

            TempData["Success"] = response.Message;
            return RedirectToAction(nameof(Index));
        }

    }
}

