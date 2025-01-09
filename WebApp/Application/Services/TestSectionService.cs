using WebApp.Application.DTOs;
using WebApp.Application.Interfaces;
using WebApp.Core.Entities;
using WebApp.Infrastructure.Data.Interfaces;

namespace WebApp.Application.Services
{
  public class TestSectionService : ITestSectionService
  {
    private readonly ITestSectionRepository _repository;

    public TestSectionService(ITestSectionRepository repository)
    {
      _repository = repository;
    }

    public async Task<ICollection<TestSectionDTO>> GetAllTestSectionsAsync()
    {
      var sections = await _repository.GetAllSectionsAsync();
      return sections.Select(MapToDTO).ToList();
    }
    private static TestSectionDTO MapToDTO(TestSectionEntity testSection)
    {
      return new TestSectionDTO()
      {
        Id = testSection.Id,
        Name = testSection.Name
      };
    }
  }
}