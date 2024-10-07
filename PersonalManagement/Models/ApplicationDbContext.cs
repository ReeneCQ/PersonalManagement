using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Personal> Personal { get; set; }
    public DbSet<Cargo> Cargos { get; set; }

    
}
