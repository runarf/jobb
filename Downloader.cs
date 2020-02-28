using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
//using BestHTTP;

namespace C2
{

  /// <summary>
  /// A class for downloading files from the Internet, saving them in a local directory.
  /// </summary>
  public class Downloader
  {
    readonly string directory;

    static readonly HttpClient httpClient = new HttpClient();

    /// <param name="directory">The path to the local directory where downloaded files are to be saved.</param>
    public Downloader(string directory)
    {
      this.directory = directory;
    }

    /// <summary>
    /// Download the content of the file at the specified URL and save it in a local file within <c>directory</c>.
    /// The download is launched on a separate thread; this method returns immediately.
    /// </summary>
    /// <param name="url">The URL to download from.</param>
    /// <returns>A Promise. The Promise is Complete()-ed when downloading finishes.</returns>
    public async Task<string> Download(string url)
    {
      var response = await httpClient.GetAsync(url);
      response.EnsureSuccessStatusCode();
      var responseBody = await response.Content.ReadAsStringAsync();
      var responseByte = await response.Content.ReadAsByteArrayAsync();
      var folder = ComputeLocalFilePathFor(url);
      WriteFile(folder, responseByte);
      Console.WriteLine("Wrote to folder {0}", folder);

      return responseBody;
    }

    string ComputeLocalFilePathFor(string url) => Path.Combine(directory, Path.GetFileName(url));

    static void WriteFile(string filePath, byte[] data)
    {
      using (var stream = File.OpenWrite(filePath))
        stream.Write(data, 0, data.Length);
    }
  }

}
