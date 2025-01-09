using WebApp.Application.DTOs;
using WebApp.Application.Interfaces;
using WebApp.Core.Entities;
using WebApp.Infrastructure.Data.Interfaces;

namespace WebApp.Application.Services
{

  public sealed class TestService : ITestService
  {
    private readonly ITestRepository _repository;
    private readonly ITestOptionRepository _optionRepository; //авасы
    public TestService(ITestRepository repository, ITestOptionRepository optionRepository)
    {
      _repository = repository;
      _optionRepository = optionRepository; //вамва
    }

    public async Task<bool> CheckAnswerAsync(int testId, List<int> selectedOptions, string userAnswer)
    {
      var test = await _repository.GetTestByIdAsync(testId);
      if (test == null)
        throw new KeyNotFoundException("Test not found");

      if (test.IsCodeTest)
      {
        return test.CorrectAnswer.Trim() == userAnswer.Trim();
      }

      var correctOptions = await _optionRepository.GetCorrectOptionsByTestIdAsync(testId);
      var correctOptionIds = correctOptions.Select(o => o.Id).ToList();

      return correctOptionIds.Count == selectedOptions.Count &&
             !correctOptionIds.Except(selectedOptions).Any();
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
        Question = test.Question,
        Options = test.Options.Select(x => new TestOptionsDTO
        {
          Id = x.Id,
          TestId = x.TestId,
          OptionText = x.OptionText,
        }).ToList()
      };
    }
  }
}