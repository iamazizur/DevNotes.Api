

using Microsoft.EntityFrameworkCore;

public class DevNotesContext : DbContext
{
    public DevNotesContext(DbContextOptions options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Note> Notes { get; set; }
}