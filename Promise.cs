using System;
using System.Collections.Generic;

namespace C2
{

  public class Promise
  {
    readonly List<Action> handlers = new List<Action>();

    public void OnComplete(Action handler) => handlers.Add(handler);

    public void Complete()
    {
      foreach (var handler in handlers)
        handler();
    }
  }

}
