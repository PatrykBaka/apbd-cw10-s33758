using apbd_cw10.Entities;
using Microsoft.EntityFrameworkCore;

namespace apbd_cw10.Data;

public class AppDbContext : DbContext
{

    protected AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<PC>  PCs { get; set; }
    public DbSet<Component> Components { get; set; }
    public DbSet<PCComponent> PCComponents { get; set; }
    public DbSet<ComponentType> ComponentTypes { get; set; }
    public DbSet<ComponentManufacturers> ComponentManufacturers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<PC>().HasData(new List<PC>()
        {
            new PC() { Id = 1, Name = "PC 1", Weight = 12f, Warranty = 12, CreatedAt = new DateTime(2026, 05, 14), Stock = 5 },
            new PC() { Id = 2, Name = "PC 2", Weight = 20f, Warranty = 24, CreatedAt = new DateTime(2026, 05, 14), Stock = 7 },
            new PC() { Id = 3, Name = "PC 3", Weight = 15f, Warranty = 12, CreatedAt = new DateTime(2026, 05, 14), Stock = 4 }
        });

        modelBuilder.Entity<Component>().HasData(new List<Component>()
        {
            new Component() { Code = "C1", Name = "Comp 1", Description = "Desc 1", ComponentManufacturersId = 1, ComponentTypesId = 1 },
            new Component() { Code = "C2", Name = "Comp 2", Description = "Desc 2", ComponentManufacturersId = 2, ComponentTypesId = 2 },
            new Component() { Code = "C3", Name = "Comp 3", Description = "Desc 3", ComponentManufacturersId = 3, ComponentTypesId = 3 }
        });

        modelBuilder.Entity<PCComponent>().HasData(new List<PCComponent>()
        {
            new PCComponent() { PCId = 1, ComponentCode = "C1", Amount = 1 },
            new PCComponent() { PCId = 1, ComponentCode = "C2", Amount = 1 },
            new PCComponent() { PCId = 2, ComponentCode = "C3", Amount = 2 }
        });

        modelBuilder.Entity<ComponentType>().HasData(new List<ComponentType>()
        {
            new ComponentType() { Id = 1, Abbrevation = "T1", Name = "Type 1" },
            new ComponentType() { Id = 2, Abbrevation = "T2", Name = "Type 2" },
            new ComponentType() { Id = 3, Abbrevation = "T3", Name = "Type 3" }
        });

        modelBuilder.Entity<ComponentManufacturers>().HasData(new List<ComponentManufacturers>()
        {
            new ComponentManufacturers() { Id = 1, Abbrevation = "M1", FullName = "Manufacturer 1", FoundationDate = new DateOnly(2000, 1, 1) },
            new ComponentManufacturers() { Id = 2, Abbrevation = "M2", FullName = "Manufacturer 2", FoundationDate = new DateOnly(2010, 5, 10) },
            new ComponentManufacturers() { Id = 3, Abbrevation = "M3", FullName = "Manufacturer 3", FoundationDate = new DateOnly(2015, 12, 20) }
        });

        
        base.OnModelCreating(modelBuilder);
    }
    
}