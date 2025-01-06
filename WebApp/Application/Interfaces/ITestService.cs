using WebApp.Application.DTOs;

namespace WebApp.Application.Interfaces
{
  public interface ITestService
  {
    Task<ICollection<TestDTO>> GetTestsBySectionAsync(int sectionId);
  }
}
