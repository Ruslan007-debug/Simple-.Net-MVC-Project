using System.ComponentModel.DataAnnotations;

namespace BuildingCompanyMVC.Domain.Entities
{
    public abstract class EntityBase
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Введіть назву")]
        [Display(Name ="Назва")]
        [MaxLength(200)]
        public string? Title { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
    }
}
