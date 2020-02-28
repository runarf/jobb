using System.Collections.Generic;
using System.Threading.Tasks;
using System;
namespace C2
{

  public class Class
  {
    readonly Downloader downloader = new Downloader("../downloads/");

    readonly Queue<string> urlsToDownload = new Queue<string>();

    public void AddUrlToDownload(string url) => urlsToDownload.Enqueue(url);

    public async Task Download()
    {
      if (urlsToDownload.Count > 0)
      {
        var currentUrl = urlsToDownload.Peek();
        var responseBody = await downloader.Download(currentUrl);
        Console.WriteLine(responseBody);
        urlsToDownload.Dequeue();
        await Download();
      }
    }
  }

}
