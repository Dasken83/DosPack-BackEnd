using Microsoft.EntityFrameworkCore;
using DospackFull.Models;

namespace DospackFull.Data
{
    public class DosContext : DbContext
    {
        public DosContext(DbContextOptions<DosContext> options) : base(options) { }

        public DbSet<DosEvent> DosEvents => Set<DosEvent>();
    }
}
