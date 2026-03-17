using BuildingCompanyMVC.Domain;
using BuildingCompanyMVC.Domain.Entities;
using BuildingCompanyMVC.Infrastructure;
using BuildingCompanyMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace BuildingCompanyMVC.Controllers
{
    public class ServicesController : Controller
    {

        private readonly DataManager _dataManager;

        public ServicesController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Service> list = await _dataManager.Services.GetServicesAsync();

            IEnumerable<ServiceDTO> listDto = HelperDTO.TransformServices(list);

            return View(listDto);
        }

        public async Task<IActionResult> Show(int id)
        {
            Service service = await _dataManager.Services.GetServiceByIdAsync(id);

            if (service == null)
            {
                return NotFound();
            }


            ServiceDTO serviceDTO = HelperDTO.TransformService(service);

            return View(serviceDTO);


        }
    }
}
