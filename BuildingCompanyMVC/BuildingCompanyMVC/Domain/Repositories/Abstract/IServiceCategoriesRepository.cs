using BuildingCompanyMVC.Domain.Entities;

namespace BuildingCompanyMVC.Domain.Repositories.Abstract
{
    public interface IServiceCategoriesRepository
    {
        Task<IEnumerable<ServiceCategory>> GetServiceCategoriesAsync();
        Task<ServiceCategory?> GetServiceCategoryByIdAsync(int id);
        Task SaveServiceCategoryAsync(ServiceCategory serviceCategory);
        Task DeleteServiceCategoryAsync(int id);
    }
}
