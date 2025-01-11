using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
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
      b => b
          .AllowAnyOrigin()
          .AllowAnyMethod()
          .AllowAnyHeader());
});

// Add DB Context
builder.Services.AddDbContext<TestDbContext>(options =>
{
  var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
  if (string.IsNullOrEmpty(connectionString))
    throw new NullReferenceException("Connection string is null or empty.");
    
  options.UseNpgsql(connectionString);
});
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

// app.UseHttpsRedirection();
app.UseCors("AllowReactApp");
app.UseAuthorization();
app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions
{
  FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")),
  RequestPath = ""
});
app.MapFallbackToFile("index.html");
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
  var context = scope.ServiceProvider.GetRequiredService<TestDbContext>();
  await context.Database.MigrateAsync();
  await DbInitializer.SeedDataAsync(context);
}
app.Run();
