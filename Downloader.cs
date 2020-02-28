using System;
using System.IO;

using BestHTTP;

namespace C2
{

  /// <summary>
  /// A class for downloading files from the Internet, saving them in a local directory.
  /// </summary>
  public class Downloader : IDownloader
  {
    readonly string directory;

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
    public Promise Download(string url)
    {
      var res = new Promise();

      new HTTPRequest(
          new Uri(url),
          (_, response) =>
          {  // This code is run once the HTTP transaction is complete:
                  if (response.IsSuccess)
              WriteFile(ComputeLocalFilePathFor(url), response.Data);
            res.Complete();
          }
      ).Send();  // Sends HTTP request in a background thread

      return res;
    }

    string ComputeLocalFilePathFor(string url) => Path.Combine(directory, Path.GetFileName(url));

    static void WriteFile(string filePath, byte[] data)
    {
      using (var stream = File.OpenWrite(filePath))
        stream.Write(data, 0, data.Length);
    }
  }

}
