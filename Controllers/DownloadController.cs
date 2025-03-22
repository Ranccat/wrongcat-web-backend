using Microsoft.AspNetCore.Mvc;
using Wrongcat.Api.Services;

namespace Wrongcat.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DownloadController(/*IDownloadService downloadService, */ILogger<DownloadController> logger)
  : ControllerBase
{
  [HttpGet("installer")]
  public async Task<IActionResult> DownloadInstaller()
  {
    logger.Log(LogLevel.Information, "Received request for installer");
    string filePath = "wwwroot/test-files/pepe.jpg";
    try
    {
      var bytes= await System.IO.File.ReadAllBytesAsync(filePath);
      return new FileContentResult(bytes, "image/jpeg");
    }
    catch (Exception e)
    {
      return StatusCode(404, "Cannot find the file");
    }
  }
}
