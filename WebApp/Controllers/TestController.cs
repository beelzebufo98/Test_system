using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Application.DTOs;
using WebApp.Application.Interfaces;


[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
  private readonly ITestService _service;

  public TestController(ITestService service)
  {
    _service = service;
  }

  [HttpGet("section/{sectionId}")]
  public async Task<ActionResult<ICollection<TestDTO>>> GetTestsBySection(int sectionId)
  {
    var tests = await _service.GetTestsBySectionAsync(sectionId);

    return Ok(tests);
  }

  //[HttpPost("check-answer")]
  //public IActionResult CheckAnswer([FromBody] AnswerCheckRequest request)
  //{
  //  var test = _context.Tests
  //      .Include(t => t.Options)
  //      .FirstOrDefault(t => t.Id == request.TestId);

  //  if (test == null) return NotFound("Test not found.");

  //  if (test.IsCodeTest)
  //  {
  //    return Ok(new
  //    {
  //      Correct = test.CorrectAnswer.Trim() == request.UserAnswer.Trim(),
  //      CorrectAnswer = test.CorrectAnswer
  //    });
  //  }

  //  var correctOptions = test.Options.Where(o => o.IsCorrect).Select(o => o.Id).ToList();
  //  var isCorrect = !correctOptions.Except(request.SelectedOptions).Any() &&
  //                  !request.SelectedOptions.Except(correctOptions).Any();

  //  return Ok(new
  //  {
  //    Correct = isCorrect,
  //    CorrectOptions = correctOptions
  //  });
  //}
}

public class AnswerCheckRequest
{
  public int TestId { get; set; }
  public List<int> SelectedOptions { get; set; } = new();
  public string UserAnswer { get; set; } = string.Empty;
}
