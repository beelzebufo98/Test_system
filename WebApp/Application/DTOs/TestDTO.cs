using WebApp.Core.Entities;

namespace WebApp.Application.DTOs
{
  public sealed class TestDTO
  {
    public required int Id { get; init; }
    public required int SectionId { get; init; }
    public required string Question { get; init; }
    public required bool IsCodeTest { get; init; }
    public required ICollection<TestOptionsDTO> Options { get; init; }
  }
}