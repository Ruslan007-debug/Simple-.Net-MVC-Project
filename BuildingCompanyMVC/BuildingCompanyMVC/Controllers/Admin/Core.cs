using BuildingCompanyMVC.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BuildingCompanyMVC.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
    public partial class AdminController : Controller
    {
        private readonly DataManager _dataManager;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger<AdminController> _logger;

        public AdminController(DataManager dataManager, IWebHostEnvironment webHostEnvironment, ILogger<AdminController> logger)
        {
            _dataManager = dataManager;
            _webHostEnvironment = webHostEnvironment;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.ServiceCategories = await _dataManager.ServiceCategories.GetServiceCategoriesAsync();
            ViewBag.Services = await _dataManager.Services.GetServicesAsync();
            return View();
        }

        public async Task<string> SaveImg(IFormFile img)
        {
            string path = Path.Combine(_webHostEnvironment.WebRootPath, "img/", img.FileName);
            await using var fileStream = new FileStream(path, FileMode.Create);
            await img.CopyToAsync(fileStream);

            return path;

        }

        public async Task<string> SaveEditorImg()
        {
            IFormFile img = Request.Form.Files[0];
            await SaveImg(img);

            return JsonSerializer.Serialize(new { location = Path.Combine("/img/", img.FileName) });
        }
            
    }   
}
