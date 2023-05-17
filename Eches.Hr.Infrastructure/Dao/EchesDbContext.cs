using Microsoft.EntityFrameworkCore;
using Eches.Hr.Infrastructure.Repository;


namespace Eches.Hr.Infrastructure.Dao
{
    public class EchesDbContext : DbContext
    {
        public EchesDbContext(DbContextOptions<EchesDbContext> options) : base(options) { }

        public virtual DbSet<CalendarRepository> Calendars { get; set; }
    }
}

