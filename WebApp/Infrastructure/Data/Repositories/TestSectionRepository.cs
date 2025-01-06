using Microsoft.EntityFrameworkCore;
using WebApp.Core.Entities;
using WebApp.Infrastructure.Data.Interfaces;

namespace WebApp.Infrastructure.Data.Repositories
{
  public sealed class TestSectionRepository : ITestSectionRepository
  {
    private readonly TestDbContext _context;

    public TestSectionRepository(TestDbContext context)
    {
      _context = context;
    }

    public async Task<ICollection<TestSectionEntity>> GetAllSectionsAsync()
    {
      return await _context.TestSections.ToListAsync();
    }

    public async Task<TestSectionEntity?> GetSectionByIdAsync(int sectionId)
    {
      return await _context.TestSections
          .FirstOrDefaultAsync(x => x.Id == sectionId);
    }
  }
}