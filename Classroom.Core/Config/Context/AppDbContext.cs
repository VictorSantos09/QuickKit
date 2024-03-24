using Classroom.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Classroom.Core.Config.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<ClassroomEntity> Classrooms { get; set; }
        public AppDbContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClassroomEntity>()
                .Property(x => x.ClassroomName)
                .HasColumnType("varchar(45)")
                .IsRequired();

            modelBuilder.Entity<ClassroomEntity>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<ClassroomEntity>()
                .HasKey(x => x.Id);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();

                var connectionString = configuration.
                       GetConnectionString("DefaultConnection");

                optionsBuilder.UseMySql(ServerVersion.AutoDetect(connectionString));
            }
        }
    }
}
