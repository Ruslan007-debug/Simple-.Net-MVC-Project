using BuildingCompanyMVC.Domain.Entities;
using BuildingCompanyMVC.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace BuildingCompanyMVC.Domain.Repositories.Entity_Framework
{
    public class EFServiceCategoriesRepository : IServiceCategoriesRepository
    {
        private readonly AppDbContext _context;
        public EFServiceCategoriesRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task DeleteServiceCategoryAsync(int id)
        {
            var serviceCategory = await _context.ServiceCategories!.FindAsync(id);
            if (serviceCategory != null)
            {
                _context.ServiceCategories.Remove(serviceCategory);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ServiceCategory>> GetServiceCategoriesAsync()
        {
            var serviceCategories = _context.ServiceCategories;
            if (serviceCategories == null)
            {
                return Enumerable.Empty<ServiceCategory>();
            }
            return await serviceCategories.Include(x => x.Services).ToListAsync();
        }

        public async Task<ServiceCategory?> GetServiceCategoryByIdAsync(int id)
        {
            if (_context.ServiceCategories == null)
            {
                return null;
            }
            return await _context.ServiceCategories
                .Include(x => x.Services)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task SaveServiceCategoryAsync(ServiceCategory serviceCategory)
        {
            _context.Entry(serviceCategory).State = serviceCategory.Id == default ? EntityState.Added : EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
