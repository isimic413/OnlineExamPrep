using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using OnlineExamPrep.DAL.Models.Mapping;

namespace OnlineExamPrep.DAL.Models
{
    public partial class OnlineExamContext : DbContext
    {
        static OnlineExamContext()
        {
            Database.SetInitializer<OnlineExamContext>(null);
        }

        public OnlineExamContext()
            : base("Name=OnlineExamContext")
        {
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<TestingArea> TestingAreas { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserClaim> UserClaims { get; set; }
        public DbSet<UserLogin> UserLogins { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new RoleMap());
            modelBuilder.Configurations.Add(new TestingAreaMap());
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new UserClaimMap());
            modelBuilder.Configurations.Add(new UserLoginMap());
        }
    }
}
