using System;
using C2;

namespace EIDU_C2
{
  class Program
  {
    static void Main(string[] args)
    {
      DownloadManager downloadManager = new DownloadManager();
      downloadManager.AddUrlToDownload("heia");
      downloadManager.Download();
      Console.WriteLine("Hello World!");
    }
  }
}
