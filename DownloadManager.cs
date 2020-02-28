using System;
using System.Collections.Generic;

namespace C2
{

  public class DownloadManager
  {
    readonly Downloader downloader = new Downloader("../downloads/");

    readonly Queue<string> urlsToDownload = new Queue<string>();

    public void AddUrlToDownload(string url) => urlsToDownload.Enqueue(url);

    public void Download()
    {
      if (urlsToDownload.Count > 0)
      {
        var currentUrl = urlsToDownload.Peek();
        var downloadPromise = downloader.Download(currentUrl);

        Action handleOnComplete = () =>
        {
          urlsToDownload.Dequeue();
          Download();
        };

        downloadPromise.OnComplete(handleOnComplete);
      }
    }
  }

}
