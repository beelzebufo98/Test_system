using Microsoft.EntityFrameworkCore;
using WebApp.Application.Interfaces;
using WebApp.Application.Services;
using WebApp.Infrastructure.Data;
using WebApp.Infrastructure.Data.Interfaces;
using WebApp.Infrastructure.Data.Repositories;
using WebApp.SeedData.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add CORS policy
builder.Services.AddCors(options =>
{
  options.AddPolicy("AllowReactApp",
      builder => builder
          .AllowAnyOrigin()
          .AllowAnyMethod()
          .AllowAnyHeader());
});

// Add DB Context
builder.Services.AddDbContext<TestDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<ITestService, TestService>();
builder.Services.AddScoped<ITestSectionService, TestSectionService>();
builder.Services.AddScoped<ITestRepository, TestRepository>();
builder.Services.AddScoped<ITestOptionRepository, TestOptionRepository>();
builder.Services.AddScoped<ITestSectionRepository, TestSectionRepository>();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowReactApp");
app.UseAuthorization();
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
  var context = scope.ServiceProvider.GetRequiredService<TestDbContext>();
  await context.Database.MigrateAsync();
  await DbInitializer.SeedDataAsync(context);
}
app.Run();
