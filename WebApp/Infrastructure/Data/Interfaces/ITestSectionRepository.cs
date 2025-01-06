using WebApp.Core.Entities;

namespace WebApp.Infrastructure.Data.Interfaces
{
  public interface ITestSectionRepository
  {
    Task<ICollection<TestSectionEntity>> GetAllSectionsAsync();
    Task<TestSectionEntity?> GetSectionByIdAsync(int sectionId);
  }
}
