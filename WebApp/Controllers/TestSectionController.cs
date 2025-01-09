using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp.Application.Interfaces;

namespace WebApp.Controllers
{
  [Route("api/sections")]
  [ApiController]
  public class TestSectionController : ControllerBase
  {
    private readonly ITestSectionService _testSectionService;
    public TestSectionController(ITestSectionService testSectionService)
    {
      _testSectionService = testSectionService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
      var sections = await _testSectionService.GetAllTestSectionsAsync();
      return Ok(sections);
    }
  }
}