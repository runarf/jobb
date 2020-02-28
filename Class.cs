using System.Collections.Generic;

namespace C2 {

    public class Class {
        readonly Downloader downloader = new Downloader("../downloads/");

        readonly Queue<string> urlsToDownload = new Queue<string>();

        public void AddUrlToDownload(string url) => urlsToDownload.Enqueue(url);

        public void Download() {
            if (urlsToDownload.Count > 0) {
                var currentUrl = urlsToDownload.Peek();
                downloader.Download(currentUrl)  // Returns a Promise.
                          .OnComplete(() => {  // This code is run once the Promise (i.e. the download) is complete:
                              urlsToDownload.Dequeue();
                              Download();
                          });
            }
        }
    }

}
