using Microsoft.EntityFrameworkCore;

namespace NetCoreApi.Models;

public class CItemContext : DbContext
{

    public CItemContext(DbContextOptions<CItemContext> options) : base(options) { }
    
    public DbSet<CItemModel> Items { get; set; } = null!;
}