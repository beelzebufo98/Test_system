using Microsoft.EntityFrameworkCore;
using WebApp.Core.Entities;
using WebApp.Infrastructure.Data.Interfaces;

namespace WebApp.Infrastructure.Data.Repositories
{
  public sealed class TestRepository : ITestRepository
  {

    private readonly TestDbContext _context;

    public TestRepository(TestDbContext context) 
    { 
      _context = context;
    }

    public async Task<ICollection<TestEntity>> GetTestsBySectionAsync(int sectionId)
    {
      return await _context.Tests.Where(x => x.SectionId == sectionId).ToListAsync();
      
    }

  }
}
