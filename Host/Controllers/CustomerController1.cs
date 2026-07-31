using Application.DTO;
using Application.Interfaces;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Host.Controllers
{
    public class CustomerController1(ICustomerService customerServices) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var response = await customerServices.GetAllCustomers();

            if (!response.IsSuccessful)
            {
                TempData["Error"] = response.Message;
                return View(new List<CustomerResponseModel>());
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
        public async Task<IActionResult> Create(CustomerRequestModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var response = await customerServices.RegisterCustomer(model);

            if (!response.IsSuccessful)
            {
                ModelState.AddModelError("", response.Message);
                return View(model);
            }

            TempData["Success"] = response.Message;
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var response = await customerServices.GetCustomerById(id);

            if (!response.IsSuccessful)
            {
                TempData["Error"] = response.Message;
                return RedirectToAction(nameof(Index));
            }

            var customer = new CustomerRequestModel
            {
                FirstName = response.Data.FirstName,
                LastName = response.Data.LastName,
                Email = response.Data.Email,
                PhoneNumber = response.Data.PhoneNumber,
                Address = response.Data.Address
            };

            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CustomerRequestModel request)
        {
            if (!ModelState.IsValid)
                return View(request);

            var response = await customerServices.UpdateCustomer(request);

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
            var response = await customerServices.GetCustomerById(id);

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
            var response = await customerServices.DeleteCustomer(id);

            TempData["Success"] = response.Message;
            return RedirectToAction(nameof(Index));
        }

    }
}

