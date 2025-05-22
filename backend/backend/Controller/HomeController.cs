using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class HomeController : ControllerBase
{
    [HttpGet]
    [Route("Index")]
    public IActionResult Index()
    {
        // Your protected data retrieval logic here
        return Ok(new { message = "Protected data retrieved successfully!" });
    }
}