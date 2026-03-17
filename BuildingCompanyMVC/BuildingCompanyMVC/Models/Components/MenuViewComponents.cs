using BuildingCompanyMVC.Domain;
using BuildingCompanyMVC.Domain.Entities;
using BuildingCompanyMVC.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace BuildingCompanyMVC.Models.Components
{
    public class MenuViewComponents: ViewComponent
    {
        private readonly DataManager _dataManager;

        public MenuViewComponents(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            IEnumerable<Service> servicesList = await _dataManager.Services.GetServicesAsync();
            IEnumerable<ServiceDTO> listDTO = HelperDTO.TransformServices(servicesList);
            return await Task.FromResult((IViewComponentResult) View("Default", listDTO));
        }
    }
}
