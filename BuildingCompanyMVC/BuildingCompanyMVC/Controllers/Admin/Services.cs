using BuildingCompanyMVC.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BuildingCompanyMVC.Controllers.Admin
{
    public partial class AdminController
    {
        public async Task<IActionResult> ServicesEdit(int id)
        {
            Service? entity = id == default ? new Service() : await _dataManager.Services.GetServiceByIdAsync(id);
            ViewBag.ServiceCategories = await _dataManager.ServiceCategories.GetServiceCategoriesAsync();

            return View(entity);
        }
        [HttpPost]
        public async Task<IActionResult> ServicesEdit(Service model, IFormFile? titleImageFile)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ServiceCategories = await _dataManager.ServiceCategories.GetServiceCategoriesAsync();
                return View(model);
            }

            if (titleImageFile != null)
            {
                model.Photo = titleImageFile.FileName;
                await SaveImg(titleImageFile);
            }

            await _dataManager.Services.SaveServiceAsync(model);
            _logger.LogInformation("Service with id: {ServiceId} was edited", model.Id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> ServicesDelete(int id)
        {
            await _dataManager.Services.DeleteServiceAsync(id);
            _logger.LogInformation("Service category with id: {ServiceId} was deleted", id);
            return RedirectToAction("Index");
        }
    }
}
