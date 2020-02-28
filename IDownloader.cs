using System.Threading.Tasks;

namespace C2
{

  public interface IDownloader
  {
    /// <summary>
    /// Download the content of the file at the specified URL.
    /// What is done with the content is up to the specific implementation.
    /// The download should normally be launched on a separate thread, with this method returning immediately.
    /// </summary>
    /// <param name="url">The URL to download from.</param>
    /// <returns>A Promise. The Promise is Complete()-ed when downloading finishes.</returns>
    Task<string> Download(string url);
  }

}
