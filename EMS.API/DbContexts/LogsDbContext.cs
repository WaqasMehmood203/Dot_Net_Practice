using EMS.API.Entities.DB2_Entities;
using Microsoft.EntityFrameworkCore;

namespace EMS.API.DbContexts
{
    public class LogsDbContext : DbContext
    {
        public LogsDbContext(DbContextOptions<LogsDbContext> options) : base(options)
        {
        }

        public DbSet<LoggedInUser> LoggedInUsers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<UserLogHistory> UserLogHistories { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<ContactInformation> ContactInformations { get; set; }

    }
}

