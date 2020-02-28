using System.Collections.Generic;

using NUnit.Framework;

namespace C2Tests
{

  public static class TestUtil
  {

    public static void AssertQueuedItemsAreEqual<T>(Queue<T> actualQueue, params T[] expectedItems)
    {
      foreach (var expectedItem in expectedItems)
      {
        Assert.That(actualQueue.Count > 0, "Expected {0}, but no actual item", expectedItem);
        var actualItem = actualQueue.Dequeue();
        Assert.AreEqual(expectedItem, actualItem, "Expected {0}, but was {1}", expectedItem, actualItem);
      }
      Assert.That(actualQueue.Count == 0, "Unexpected item: {0}", actualQueue.Peek());
    }
  }

}
