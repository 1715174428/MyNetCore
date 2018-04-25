using Microsoft.EntityFrameworkCore;
using Model.Config;
using System.Reflection;
namespace Model
{
    public class EfDbContext : DbContext
    {
        public DbSet<UserInfo> UserInfos { get; set; }
        public DbSet<Role> Roles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.Load("Model"));
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseMySql("Server=192.168.0.172;database=mynetcore;uid=root;pwd=Lm160713");
        }
    }
}
