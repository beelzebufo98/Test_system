using WebApp.Application.DTOs;

namespace WebApp.Application.Interfaces
{
  public interface ITestSectionService
  {
    Task<ICollection<TestSectionDTO>> GetAllTestSectionsAsync();
  }
}
