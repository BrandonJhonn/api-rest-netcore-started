using Microsoft.EntityFrameworkCore;

namespace NetCoreApi.Models;

public class CItemContext : DbContext
{

    public CItemContext(DbContextOptions<CItemContext> options) : base(options) { }
    
    public DbSet<CItemModel> Items { get; set; } = null!;

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseNpgsql(@"Host=localhost;Database=db_todoNetCore;Username=postgres;Password=postgres15");
}