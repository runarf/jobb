using NUnit.Framework;
using System;
using C2;
using System.Threading.Tasks;

namespace EIDU_C2
{
  public class Tests
  {
    [SetUp]
    public void Setup()
    {
    }

    public void Test1()
    {
      Console.WriteLine("HEIA");
      Assert.Fail();
    }

    [Test]
    public async Task DownloadManager_Runs()
    {
      Console.WriteLine("Running tests");
      var downloadManager = new DownloadManager();
      downloadManager.AddUrlToDownload("https://pokeapi.co/api/v2/pokemon/ditto/");
      await downloadManager.Download();
      Assert.IsFalse(true);

    }
  }
}