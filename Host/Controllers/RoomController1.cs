using Application.DTO;
using Application.Interfaces;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers
{
    public class RoomController1(IRoomService roomServices) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var response = await roomServices.GetAllRooms();

            if (!response.IsSuccessful)
            {
                TempData["Error"] = response.Message;
                return View(new List<RoomResponseModel>());
            }

            return View(response.Data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RoomRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var response = await roomServices.AddRoom(model);

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
            var response = await roomServices.GetRoom(id);

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
            var response = await roomServices.DeleteRoom(id);

            TempData["Success"] = response.Message;
            return RedirectToAction(nameof(Index));
        }
    }
}

