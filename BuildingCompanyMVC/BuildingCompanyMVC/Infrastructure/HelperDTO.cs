using BuildingCompanyMVC.Domain.Entities;
using BuildingCompanyMVC.Models;

namespace BuildingCompanyMVC.Infrastructure
{
    public static class HelperDTO
    {
        public static ServiceDTO TransformService(Service entity)
        {
            ServiceDTO serviceDTO = new ServiceDTO
            {
                Id = entity.Id,
                CategoryName = entity.ServiceCategory?.Title,
                Title = entity.Title,
                DescriptionShort = entity.DescriptionShort,
                Description = entity.Description,
                PhotoFileName = entity.Photo,
                Type = entity.Type.ToString()
            };

            return serviceDTO;
        }

        public static IEnumerable<ServiceDTO> TransformServices(IEnumerable<Service> entities)
        {
            List<ServiceDTO> serviceDTOs = new List<ServiceDTO>();
            foreach (var entity in entities)
            {
                ServiceDTO serviceDTO = TransformService(entity);
                serviceDTOs.Add(serviceDTO);
            }
            return serviceDTOs;
        }

    }
}
