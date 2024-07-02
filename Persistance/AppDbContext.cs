using Microsoft.EntityFrameworkCore;

namespace LeadMaster.Persistance;

public class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=postgres;User Id=postgres;Password=Vlas_1234");
        
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChatMessage>(builder =>
        {
            builder.HasKey(p => p.Id);

            builder.HasOne(p => p.Chat)
                .WithMany(p => p.Messages);
        });

        modelBuilder.Entity<Chat>(builder =>
        {
            builder.HasKey(p => p.Id);
        });
    }
}