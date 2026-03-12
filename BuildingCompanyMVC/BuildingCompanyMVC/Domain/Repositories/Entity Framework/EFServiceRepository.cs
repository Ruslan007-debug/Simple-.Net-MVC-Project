using BuildingCompanyMVC.Domain.Entities;
using BuildingCompanyMVC.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace BuildingCompanyMVC.Domain.Repositories.Entity_Framework
{
    public class EFServiceRepository : IServicesRepository
    {
        private readonly AppDbContext _context;
        public EFServiceRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task DeleteServiceAsync(int id)
        {
            var service = await _context.Services!.FindAsync(id);
            if (service != null)
            {
                _context.Services.Remove(service);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Service>> GetServicesAsync()
        {
            var services = _context.Services;
            if (services == null)
            {
                return Enumerable.Empty<Service>();
            }
            return await services.Include(x=>x.ServiceCategory).ToListAsync();
        }

        public async Task<Service?> GetServiceByIdAsync(int id)
        {
            if (_context.Services == null)
            {
                return null;
            }
            return await _context.Services
                .Include(x => x.ServiceCategory)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task SaveServiceAsync(Service service)
        {
            _context.Entry(service).State = service.Id == default ? EntityState.Added : EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
