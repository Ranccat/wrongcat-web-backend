using Microsoft.AspNetCore.Mvc;

using Wrongcat.Api.Services;

namespace Wrongcat.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DownloadController(IDownloadService downloadService) : ControllerBase
{
  [HttpGet("installer")]
  public async Task<IActionResult> DownloadInstaller()
  {
    // TODO
    return StatusCode(404, "File not ready");
  }

  [HttpGet("pepe")]
  public async Task<IActionResult> DownloadPepe()
  {
    try
    {
      var bytes = await downloadService.GetPepeAsync();
      return new FileContentResult(bytes, "image/jpeg");
    }
    catch (Exception e)
    {
      return StatusCode(404, "Cannot find the file");
    }
  }
}
