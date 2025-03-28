using Microsoft.EntityFrameworkCore;
using EcoSimGame.Models.GameModels;
using EcoSimGame.Models.AuthModels;

namespace EcoSimGame.Data;

public class GameDbContext : DbContext
{
    public GameDbContext(DbContextOptions<GameDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Player> Players { get; set; }
    public DbSet<Material> Materials { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Inventory> Inventories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Material>()
            .Property(m => m.Price)
            .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<Product>()
            .Property(p => p.Cost)
            .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<Product>()
            .Property(p => p.Price)
            .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<Player>()
            .HasOne(p => p.User)
            .WithOne(u => u.Player) 
            .HasForeignKey<Player>(p => p.UserId);

        modelBuilder.Entity<Inventory>()
            .HasOne(i => i.Player)
            .WithMany(p => p.Inventories)
            .HasForeignKey(i => i.PlayerId);

        modelBuilder.Entity<Inventory>()
            .HasOne(i => i.Material)
            .WithMany()
            .HasForeignKey(i => i.MaterialId);

        modelBuilder.Entity<Inventory>()
            .HasOne(i => i.Product)
            .WithMany()
            .HasForeignKey(i => i.ProductId);
    }
}