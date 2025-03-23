namespace Wrongcat.Api.Services;

public interface IDownloadService
{
  Task<byte[]> GetPepeAsync();
}

public class DownloadService : IDownloadService {
  private const string PepeImagePath = "wwwroot/test-files/pepe.jpg";
  
  public async Task<byte[]> GetPepeAsync()
  {
    return await File.ReadAllBytesAsync(PepeImagePath);
  }
}
