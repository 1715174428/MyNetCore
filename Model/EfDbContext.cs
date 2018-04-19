using Microsoft.EntityFrameworkCore;
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
            modelBuilder.AddEntityConfigurationFromAssembly(Assembly.Load("Model"));
            var userBuilder = modelBuilder.Entity<UserInfo>();
             userBuilder.HasOne(e => e.Role).WithMany().HasForeignKey(i => i.RoleId).IsRequired();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseMySql("Server=192.168.0.172;database=mynetcore;uid=root;pwd=Lm160713");
        }
    }
}
