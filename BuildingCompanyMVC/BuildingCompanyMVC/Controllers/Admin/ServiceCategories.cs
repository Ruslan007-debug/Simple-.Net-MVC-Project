using BuildingCompanyMVC.Domain;
using BuildingCompanyMVC.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BuildingCompanyMVC.Controllers.Admin
{
    public partial class AdminController
    {
        public async Task<IActionResult> ServiceCategoriesEdit(int id)
        {
            ServiceCategory? entity = id == default ? new ServiceCategory() : await _dataManager.ServiceCategories.GetServiceCategoryByIdAsync(id);

            return View(entity);
        }

        [HttpPost]
        public async Task<IActionResult> ServiceCategoriesEdit(ServiceCategory model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _dataManager.ServiceCategories.SaveServiceCategoryAsync(model);
            _logger.LogInformation("Service category with id: {ServiceCategoryId} was edited", model.Id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> ServiceCategoriesDelete(int id)
        {
            await _dataManager.ServiceCategories.DeleteServiceCategoryAsync(id);

            _logger.LogInformation("Service category with id: {ServiceCategoryId} was deleted", id);

            return RedirectToAction("Index");
        }
    }
}
