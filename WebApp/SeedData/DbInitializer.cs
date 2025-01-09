using System.Text.Json;
using System.Text.Json.Serialization;
using WebApp.Core.Entities;
using WebApp.Infrastructure.Data;

namespace WebApp.SeedData.Data;

public static class DbInitializer
{
  public static async Task SeedDataAsync(TestDbContext context)
  {
    // Проверяем, есть ли уже данные
    if (context.TestSections.Any())
      return;

    // Читаем JSON файл
    var jsonString = await File.ReadAllTextAsync("SeedData/tests.json");
    var data = JsonSerializer.Deserialize<TestSectionsData>(jsonString);

    if (data?.TestSections == null)
      return;

    // Добавляем секции тестов
    foreach (var section in data.TestSections)
    {
      var testSection = new TestSectionEntity
      {
        Id = section.Id,
        Name = section.Name,
        Tests = new List<TestEntity>()
      };

      // Добавляем тесты для каждой секции
      if (section.Tests != null)
      {
        foreach (var test in section.Tests)
        {
          var testEntity = new TestEntity
          {
            Id = test.Id,
            SectionId = test.SectionId,
            Question = test.Question,
            IsCodeTest = test.IsCodeTest,
            CorrectAnswer = test.CorrectAnswer,
            TestNumber = test.TestNumber,
            Options = new List<TestOptionEntity>()
          };

          // Добавляем варианты ответов для каждого теста
          if (test.Options != null)
          {
            foreach (var option in test.Options)
            {
              testEntity.Options.Add(new TestOptionEntity
              {
                Id = option.Id,
                TestId = option.TestId,
                OptionText = option.OptionText,
                IsCorrect = option.IsCorrect
              });
            }
          }

          testSection.Tests.Add(testEntity);
        }
      }

      context.TestSections.Add(testSection);
    }

    await context.SaveChangesAsync();
  }
}

// Классы для десериализации JSON
public class TestSectionsData
{
  [JsonPropertyName("testSections")]
  public List<TestSectionData> TestSections { get; set; }
}

public class TestSectionData
{
  [JsonPropertyName("id")]
  public int Id { get; set; }

  [JsonPropertyName("name")]
  public string Name { get; set; }

  [JsonPropertyName("tests")]
  public List<TestData> Tests { get; set; }
}

public class TestData
{
  [JsonPropertyName("id")]
  public int Id { get; set; }

  [JsonPropertyName("sectionId")]
  public int SectionId { get; set; }

  [JsonPropertyName("question")]
  public string Question { get; set; }

  [JsonPropertyName("isCodeTest")]
  public bool IsCodeTest { get; set; }

  [JsonPropertyName("correctAnswer")]
  public string CorrectAnswer { get; set; }

  [JsonPropertyName("testNumber")]
  public int TestNumber { get; set; }

  [JsonPropertyName("options")]
  public List<TestOptionData> Options { get; set; }
}

public class TestOptionData
{
  [JsonPropertyName("id")]
  public int Id { get; set; }

  [JsonPropertyName("testId")]
  public int TestId { get; set; }

  [JsonPropertyName("optionText")]
  public string OptionText { get; set; }

  [JsonPropertyName("isCorrect")]
  public bool IsCorrect { get; set; }
}

