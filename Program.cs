using System;
using System.Threading.Tasks;
using C2;

namespace EIDU_C2
{
  class Program
  {
    static async Task Main(string[] args)
    {
      Console.WriteLine("Hello World!");
      var downloadManager = new DownloadManager();
      downloadManager.AddUrlToDownload("https://pokeapi.co/api/v2/pokemon/ditto/");
      await downloadManager.Download();
    }
  }
}
