using WebApp.Application.DTOs;
using WebApp.Controllers;
using WebApp.Core.Entities;
using static TestController;

namespace WebApp.Application.Interfaces
{
  public interface ITestService
  {
    Task<ICollection<TestDTO>> GetTestsBySectionAsync(int sectionId);
    Task<bool> CheckAnswerAsync(int testId, List<int> selectedOptions, string userAnswer); //тут пока непонятно

  }
}
