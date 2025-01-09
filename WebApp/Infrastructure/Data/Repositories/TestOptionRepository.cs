using Microsoft.EntityFrameworkCore;
using WebApp.Core.Entities;
using WebApp.Infrastructure.Data.Interfaces;

namespace WebApp.Infrastructure.Data.Repositories
{
  public sealed class TestOptionRepository : ITestOptionRepository
  {
    private readonly TestDbContext _context;

    public TestOptionRepository(TestDbContext context)
    {
      _context = context;
    }

    public async Task<ICollection<TestOptionEntity>> GetOptionsByTestIdAsync(int testId)
    {
      return await _context.TestOptions
          .Where(x => x.TestId == testId)
          .ToListAsync();
    }

    public async Task<ICollection<TestOptionEntity>> GetCorrectOptionsByTestIdAsync(int testId)
    {
      return await _context.TestOptions
          .Where(x => x.TestId == testId && x.IsCorrect)
          .ToListAsync();
    }
  }
}