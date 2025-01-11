using CourseStore.BLL.Tags.Commands;
using CourseStore.DAL.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ContextStoreDbContext>(p => p.UseSqlServer("Server=;Initial Catalog=CleanCourse;Integrated Security=True").AddInterceptors(new AddAuditFieldInterceptor()));

builder.Services.AddMediatR(cfx => cfx.RegisterServicesFromAssembly(typeof(CreateTagHandler).Assembly));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at httcps://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
