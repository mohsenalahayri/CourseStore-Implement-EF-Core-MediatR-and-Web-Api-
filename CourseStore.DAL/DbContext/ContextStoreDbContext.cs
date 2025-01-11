using CourseStore.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CourseStore.DAL.Context;

public class ContextStoreDbContext : DbContext
{
    public DbSet<Course> Courses { get; set; }

    public DbSet<Teacher> Teachers { get; set; }

    public DbSet<CourseTeacher> CourseTeachers { get; set; }

    public DbSet<CourseComment> CourseComments { get; set; }

    public DbSet<Tag> Tags { get; set; }

    public DbSet<Order> Order { get; set; }

    public ContextStoreDbContext(DbContextOptions<ContextStoreDbContext> options) : base(options)
    {

    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

        foreach (var item in modelBuilder.Model.GetEntityTypes())
        {
            // با استفاده از بخش item.ClrType به کل Config های entity های موجود در EF دسترسی پیدا کردیم
            modelBuilder.Entity(item.ClrType).Property<string>("CreateBy").HasMaxLength(50);
            modelBuilder.Entity(item.ClrType).Property<string>("UpdateBy").HasMaxLength(50);
            modelBuilder.Entity(item.ClrType).Property<DateTime>("CreateDate").HasMaxLength(50);
            modelBuilder.Entity(item.ClrType).Property<DateTime>("UpdateDate").HasMaxLength(50);
        }
    }

    #region GetConnerctionStringOnConfiguration

    //private readonly string _connectionString;

    //public ContextStoreDbContext(string connectionString)
    //{
    //    _connectionString = connectionString;
    //}

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    optionsBuilder.UseSqlServer(_connectionString);
    //}

    #endregion
}