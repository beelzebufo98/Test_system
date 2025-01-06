using System.ComponentModel.DataAnnotations;

namespace WebApp.Core.Entities
{
  public sealed class TestEntity
  {
    public int Id { get; init; }

    public int SectionId { get; init; }

    [Required]
    [StringLength(1000)]
    public string Question { get; init; }

    public bool IsCodeTest { get; init; }

    [Required]
    [StringLength(2000)]
    public string CorrectAnswer { get; init; }

    public int TestNumber { get; init; }
    public ICollection<TestOptionEntity> Options { get; init; }
  }
}
