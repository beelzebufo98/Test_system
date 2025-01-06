using WebApp.Application.DTOs;
using WebApp.Application.Interfaces;
using WebApp.Core.Entities;
using WebApp.Infrastructure.Data.Interfaces;

namespace WebApp.Application.Services
{
  public sealed class TestService : ITestService
  {
    private readonly ITestRepository _repository;
    public TestService(ITestRepository repository) 
    { 
      _repository = repository;
    }
    public async Task<ICollection<TestDTO>> GetTestsBySectionAsync(int sectionId)
    {
      var tests = await _repository.GetTestsBySectionAsync(sectionId);
      return tests.Select(MapToDTO).ToList();
      
    }
    private static TestDTO MapToDTO(TestEntity test)
    {
      return new TestDTO()
      {
        Id = test.Id,
        IsCodeTest = test.IsCodeTest,
        SectionId = test.SectionId,
        Question = test.Question
      };
    }
  }
}
