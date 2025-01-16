using CourseStore.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CourseStore.DAL.Courses;

public class CourseConfig : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        var dateTimeConverter = new ValueConverter<DateTime, string>(
            v => v.ToString("yyyy-MM-dd HH:mm:ss"), // ذخیره در دیتابیس به فرمت کامل
            v => DateTime.ParseExact(v, "yyyy-MM-dd HH:mm:ss", null) // خواندن از دیتابیس و تبدیل به DateTime
        );

        builder.Property(p => p.StartDate)
            .HasConversion(dateTimeConverter);

        builder.Property(p => p.EndDate)
            .HasConversion(dateTimeConverter);

        builder.Property(p => p.ImageUrl).IsRequired().HasMaxLength(1000);
        builder.Property(p => p.Title).IsRequired().HasMaxLength(100);
        builder.Property(p => p.Description).IsRequired();
        builder.Property(p => p.shortDescription).IsRequired().HasMaxLength(500);
    }
}