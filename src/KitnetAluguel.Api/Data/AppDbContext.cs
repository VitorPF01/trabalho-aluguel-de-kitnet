using KitnetAluguel.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace KitnetAluguel.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<Kitnet> Kitnets => Set<Kitnet>();
    public DbSet<Tenant> Tenants => Set<Tenant>();
    public DbSet<LeaseContract> LeaseContracts => Set<LeaseContract>();
    public DbSet<Payment> Payments => Set<Payment>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();

        modelBuilder.Entity<LeaseContract>()
            .HasOne(l => l.Kitnet)
            .WithMany()
            .HasForeignKey(l => l.KitnetId);

        modelBuilder.Entity<LeaseContract>()
            .HasOne(l => l.Tenant)
            .WithMany()
            .HasForeignKey(l => l.TenantId);

        modelBuilder.Entity<Payment>()
            .HasOne(p => p.LeaseContract)
            .WithMany()
            .HasForeignKey(p => p.LeaseContractId);

        // precisao para valores monetarios
        modelBuilder.Entity<Kitnet>()
            .Property(k => k.BaseRentValue)
            .HasPrecision(18, 2);

        modelBuilder.Entity<LeaseContract>()
            .Property(c => c.RentValue)
            .HasPrecision(18, 2);

        modelBuilder.Entity<Payment>()
            .Property(p => p.Amount)
            .HasPrecision(18, 2);
    }
}
