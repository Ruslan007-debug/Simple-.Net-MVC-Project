using BuildingCompanyMVC.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BuildingCompanyMVC.Domain
{
    
    public class AppDbContext: IdentityDbContext
    {
        public DbSet<ServiceCategory>? ServiceCategories { get; set; }
        public DbSet<Service>? Services { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            string AdminName = "Admin";
            string roleAdminId = Guid.NewGuid().ToString();
            string userAdminId = Guid.NewGuid().ToString();

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = roleAdminId,
                Name = AdminName,
                NormalizedName = AdminName.ToUpper()
            });

            modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = userAdminId,
                UserName = AdminName,
                NormalizedUserName = AdminName.ToUpper(),
                Email = "admin@admin.com",
                NormalizedEmail = "admin@admin.com",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(new IdentityUser(), AdminName),
                EmailConfirmed = true,
                SecurityStamp = string.Empty,
                PhoneNumberConfirmed = true
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = roleAdminId,
                UserId = userAdminId
            });

        }
    }


}
