using WebApp.Core.Entities;

namespace WebApp.Infrastructure.Data.Interfaces
{
  public interface ITestOptionRepository
  {
    Task<ICollection<TestOptionEntity>> GetOptionsByTestIdAsync(int testId);
    Task<ICollection<TestOptionEntity>> GetCorrectOptionsByTestIdAsync(int testId);
  }
}
