
namespace WebApp.Core.Entities
{
  public sealed class TestOptionEntity
  {
    public int Id { get; init; }
    public int TestId { get; init; }
    public string OptionText { get; init; }
    public bool IsCorrect { get; init; }
  }
}
