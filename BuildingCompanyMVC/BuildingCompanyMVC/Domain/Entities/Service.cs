using BuildingCompanyMVC.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace BuildingCompanyMVC.Domain.Entities
{
    public class Service: EntityBase
    {
        [Display(Name = "Виберіть категорію, до якої відноситься послуга")]
        public int? ServiceCategoryId { get; set; }
        public ServiceCategory? ServiceCategory { get; set; }

        [Display( Name = "Короткий опис")]
        [MaxLength(3_000)]
        public string? DescriptionShort { get; set; }

        [Display(Name = "Повний опис")]
        [MaxLength(10_000)]
        public string? Description { get; set; }

        [Display(Name = "Титульна сторінка")]
        [MaxLength(300)]
        public string? Photo { get; set; }

        [Display(Name = "Тип послуги")]
        public ServiceTypeEnum Type { get; set; }
    }
}
