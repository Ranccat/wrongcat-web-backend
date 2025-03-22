using System.Net.WebSockets;

namespace Wrongcat.Api.Services;

public interface IDownloadService
{
  Task SendInstallerAsync(WebSocket webSocket);
}

public class DownloadService : IDownloadService {
  public async Task SendInstallerAsync(WebSocket webSocket)
  {
    // 
  }
}
