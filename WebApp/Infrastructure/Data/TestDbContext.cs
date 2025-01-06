using Microsoft.EntityFrameworkCore;
using WebApp.Core.Entities;

namespace WebApp.Infrastructure.Data;

public class TestDbContext : DbContext
{
  public TestDbContext(DbContextOptions<TestDbContext> options) : base(options) { }

  public DbSet<TestEntity> Tests { get; set; }
  public DbSet<TestSectionEntity> TestSections { get; set; }
  public DbSet<TestOptionEntity> TestOptions { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<TestEntity>().Navigation(x => x.Options).AutoInclude();
    modelBuilder.Entity<TestEntity>()
        .HasOne<TestSectionEntity>()
        .WithMany(s => s.Tests)
        .HasForeignKey(t => t.SectionId);

    modelBuilder.Entity<TestOptionEntity>()
        .HasOne<TestEntity>()
        .WithMany(t => t.Options)
        .HasForeignKey(o => o.TestId);

    modelBuilder.Entity<TestEntity>()
        .Property(t => t.Question)
        .IsRequired()
        .HasMaxLength(1000);

    modelBuilder.Entity<TestEntity>()
        .Property(t => t.CorrectAnswer)
        .IsRequired()
        .HasMaxLength(2000);
  }
  //protected override void OnModelCreating(ModelBuilder modelBuilder)
  //{
  //  modelBuilder.Entity<TestEntity>()
  //      .HasOne(t => t.Section)
  //      .WithMany(s => s.Tests)
  //      .HasForeignKey(t => t.SectionId);

  //  modelBuilder.Entity<TestOptionEntity>()
  //      .HasOne(o => o.Test)
  //      .WithMany(t => t.Options)
  //      .HasForeignKey(o => o.TestId);
  //}
}
