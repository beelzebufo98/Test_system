using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Application.DTOs;
using WebApp.Application.Interfaces;
using WebApp.Infrastructure.Data.Interfaces;


[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
  private readonly ITestService _service;

  public TestController(ITestService service)
  {
    _service = service;
  }

  [HttpPost("check-answer")]
  public async Task<ActionResult<bool>> CheckAnswer([FromBody] AnswerCheckRequest request)
  {
    try
    {
      var isCorrect = await _service.CheckAnswerAsync(
          request.TestId,
          request.SelectedOptions,
          request.UserAnswer
      );

      return Ok(isCorrect);
    }
    catch (KeyNotFoundException)
    {
      return NotFound("Test not found");
    }
  }

  [HttpGet("section/{sectionId}")]
  public async Task<ActionResult<ICollection<TestDTO>>> GetTestsBySection(int sectionId)
  {
    var tests = await _service.GetTestsBySectionAsync(sectionId);
    return Ok(tests);
  }
}

public class AnswerCheckRequest
{
  public int TestId { get; set; }
  public List<int> SelectedOptions { get; set; } = new();
  public string UserAnswer { get; set; } = string.Empty;
}