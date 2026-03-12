using BuildingCompanyMVC.Domain.Repositories.Abstract;

namespace BuildingCompanyMVC.Domain
{
    public class DataManager
    {
        public IServicesRepository Services { get; set; }
        public IServiceCategoriesRepository ServiceCategories { get; set; }
        public DataManager(IServicesRepository servicesRepository, IServiceCategoriesRepository serviceCategoriesRepository)
        {
            Services = servicesRepository;
            ServiceCategories = serviceCategoriesRepository;
        }
    }
}
