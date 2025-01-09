
namespace WebApp.Core.Entities
{
  public sealed class TestSectionEntity
  {
    public int Id { get; init; }
    public string Name { get; init; }
    public ICollection<TestEntity> Tests { get; init; }
  }
}
