
using WebApp.Core.Entities;

namespace WebApp.Infrastructure.Data.Interfaces
{
  public interface ITestRepository
  {

    Task<ICollection<TestEntity>> GetTestsBySectionAsync(int sectionId);
    Task<TestEntity?> GetTestByIdAsync(int testId); //tyyhfg
  }
}
