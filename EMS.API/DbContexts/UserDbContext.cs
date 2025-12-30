using EMS.API.Entities.DB3_Entities;
using Microsoft.EntityFrameworkCore;

namespace EMS.API.DbContexts
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
        }

        public DbSet<ApiLog> ApiLogs { get; set; }
        public DbSet<ApplicationLog> ApplicationLogs { get; set; }
        public DbSet<DbLog> DbLogs { get; set; }
    }
}
