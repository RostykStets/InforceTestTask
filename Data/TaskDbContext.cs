using InforceTestTask.Models;
using Microsoft.EntityFrameworkCore;

namespace InforceTestTask.Data
{
    public class TaskDbContext : DbContext
    {
        public TaskDbContext(DbContextOptions<TaskDbContext> options): base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

               var connectionString = configuration.GetConnectionString("TestTaskConnection");
                optionsBuilder.UseNpgsql(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>().HasKey(a => a.Id);
            modelBuilder.Entity<AuthorizedUser>().HasKey(user => user.Id);
            modelBuilder.Entity<RegistrationKey>().HasKey(key => key.Id);
            modelBuilder.Entity<Url>().HasKey(url => url.Id);
            modelBuilder.Entity<RegistrationKey>().HasData(new RegistrationKey
            {
                Id = 1, Key = "qwerty12"
            });
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<AuthorizedUser> AuthorizedUsers { get; set; }
        public DbSet<RegistrationKey> RegistrationKeys { get; set; }
        public DbSet<Url> Urls { get; set; }
    }
}
