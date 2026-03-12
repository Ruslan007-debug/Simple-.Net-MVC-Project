using BuildingCompanyMVC.Domain.Entities;

namespace BuildingCompanyMVC.Domain.Repositories.Abstract
{
    public interface IServicesRepository
    {
        Task<IEnumerable<Service>> GetServicesAsync();
        Task<Service?> GetServiceByIdAsync(int id);
        Task SaveServiceAsync(Service service);
        Task DeleteServiceAsync(int id);

    }
}
