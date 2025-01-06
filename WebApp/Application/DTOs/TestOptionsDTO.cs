namespace WebApp.Application.DTOs
{
  public sealed class TestOptionsDTO
  {
    public required int Id { get; init; }

    public required int TestId { get; init; }
    public required string OptionText { get; init; }
  }
}
