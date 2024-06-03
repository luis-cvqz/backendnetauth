using backendnet.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace backendnet.Data.Seed;

public static class SeedIdentityUserData
{
    public static void SeedUserIdentityData(this ModelBuilder modelBuilder)
    {
        string AdministradorRoleId = Guid.NewGuid().ToString(); 
        modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
        {
            Id = AdministradorRoleId,
            Name = "Administrador",
            NormalizedName = "Administrador".ToUpper()
        });

        string UsuarioRoleId = Guid.NewGuid().ToString(); 
        modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
        {
            Id = UsuarioRoleId,
            Name = "Usuario",
            NormalizedName = "Usuario".ToUpper()
        });

        var UsuarioId = Guid.NewGuid().ToString(); 
        modelBuilder.Entity<CustomIdentityUser>().HasData(new CustomIdentityUser
        {
            Id = UsuarioId,
            UserName = "lcasas@uv.mx",
            Email = "lcasas@uv.mx",
            NormalizedEmail = "lcasas@uv.mx".ToUpper(),
            Nombre = "Luis Manuel Casas Vazquez",
            NormalizedUserName = "lcasas@uv.mx".ToUpper(),
            PasswordHash = new PasswordHasher<CustomIdentityUser>().HashPassword(null!, "passwordSeguro123"),
            Protegido = true 
        });

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            RoleId = AdministradorRoleId,
            UserId = UsuarioId
        });

        UsuarioId = Guid.NewGuid().ToString();
        modelBuilder.Entity<CustomIdentityUser>().HasData(
            new CustomIdentityUser
            {
                Id = UsuarioId,
                UserName = "patito@uv.mx",
                Email = "patito@uv.mx",
                NormalizedEmail = "patito.uv.mx".ToUpper(),
                Nombre = "Usuario Patito",
                NormalizedUserName = "patito.uv.mx".ToUpper(),
                PasswordHash = new PasswordHasher<CustomIdentityUser>().HashPassword(null!, "patito"),
            }
        );

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                RoleId = UsuarioRoleId,
                UserId = UsuarioId
            }
        );
    }
}