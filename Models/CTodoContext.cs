using Microsoft.EntityFrameworkCore;

namespace NetCoreApi.Models;

public class CTodoContext : DbContext
{
    public CTodoContext(DbContextOptions<CTodoContext> options) : base(options) { }

    public DbSet<CTodoItemModel> ColTodoItem { get; set; } = null!;
}