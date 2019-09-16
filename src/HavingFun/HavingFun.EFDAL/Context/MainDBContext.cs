using HavingFun.Common.Consts;
using HavingFun.Common.Helpers;
using HavingFun.EFDAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace HavingFun.EFDAL.Context
{
    public class MainDBContext : DbContext
    {
        public MainDBContext() : base(new DbContextOptionsBuilder<MainDBContext>()
            .UseSqlServer(@"Server=(LocalDB)\MSSQLLocalDB; Integrated Security=true;").Options)
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
                .HasKey(x => new { x.ClaimId, x.UserId });

            modelBuilder.Entity<UserRoles>()
                .HasKey(x => new { x.RoleId, x.UserId });

            var firstUser = new EFDAL.Entities.User()
            {
                FirstName = "Karol",
                LastName = "LatkaAdmin",
                EmailAddress = "karolas-borys@wp.pl",
                PasswordHash = new SHA256PasswordHasher().HashPassword("admin"),
                IsActivated = true,
                Username = "KarolAdmin",
                Id = 1
            };
          

            var firstUserClaim = new Claim()
            {
                Id = 1,
                Type = CustomClaims.CanSeeUsersList,
                Value = ClaimsDefaultValues.Allow
            };

            var firstUserUserClaim = new UserClaims()
            {
                UserId = 1,
                ClaimId = 1,
            };


            var secondUser = new EFDAL.Entities.User()
            {
                FirstName = "Karol",
                LastName = "LatkaRegular",
                EmailAddress = "karolas-borys2@wp.pl",
                PasswordHash = new SHA256PasswordHasher().HashPassword("karol"),
                IsActivated = true,
                Username = "Karol",
                Id = 2
            };

            modelBuilder.Entity<Claim>().HasData(firstUserClaim);
            modelBuilder.Entity<User>().HasData(firstUser, secondUser);
            modelBuilder.Entity<UserClaims>().HasData(firstUserUserClaim);
        }
    }
}
