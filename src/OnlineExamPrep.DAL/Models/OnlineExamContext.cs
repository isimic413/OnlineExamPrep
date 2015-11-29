using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;
using OnlineExamPrep.DAL.Models.Mapping;

namespace OnlineExamPrep.DAL.Models
{
    public partial class OnlineExamContext : DbContext, IOnlineExamContext
    {
        static OnlineExamContext()
        {
            Database.SetInitializer<OnlineExamContext>(null);
        }

        public OnlineExamContext()
            : base("Name=OnlineExamContext")
        {
        }

        public DbSet<QuestionTypeEntity> QuestionTypes { get; set; }
        public DbSet<RoleEntity> Roles { get; set; }
        public DbSet<TestingAreaEntity> TestingAreas { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<UserClaimEntity> UserClaims { get; set; }
        public DbSet<UserLoginEntity> UserLogins { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new QuestionTypeEntityMap());
            modelBuilder.Configurations.Add(new RoleEntityMap());
            modelBuilder.Configurations.Add(new TestingAreaEntityMap());
            modelBuilder.Configurations.Add(new UserEntityMap());
            modelBuilder.Configurations.Add(new UserClaimEntityMap());
            modelBuilder.Configurations.Add(new UserLoginEntityMap());
        }
    }

    public interface IOnlineExamContext : IDisposable
    {
        DbSet<QuestionTypeEntity> QuestionTypes { get; set; }
        DbSet<RoleEntity> Roles { get; set; }
        DbSet<TestingAreaEntity> TestingAreas { get; set; }
        DbSet<UserEntity> Users { get; set; }
        DbSet<UserClaimEntity> UserClaims { get; set; }
        DbSet<UserLoginEntity> UserLogins { get; set; }
		DbSet<TEntity> Set<TEntity>() where TEntity : class;
		DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
		Task<int> SaveChangesAsync();
   }
}
