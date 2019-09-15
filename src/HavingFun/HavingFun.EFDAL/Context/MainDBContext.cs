using HavingFun.EFDAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace HavingFun.EFDAL.Context
{
    public class MainDBContext : DbContext
    {
        public MainDBContext():base(new DbContextOptionsBuilder<MainDBContext>().UseNpgsql("Server = 127.0.0.1; Port = 5432; Database = HavingFun; User Id = postgres; Password = password").Options)
        {
            
        }

        public MainDBContext(DbContextOptions<MainDBContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Claim> Claims { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserClaims>()
                .HasKey(x => new { x.ClaimId, x.UserId});

            modelBuilder.Entity<UserRoles>()
                .HasKey(x => new { x.RoleId, x.UserId });
        }
    }
}
