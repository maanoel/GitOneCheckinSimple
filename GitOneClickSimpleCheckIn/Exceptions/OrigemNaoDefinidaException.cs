using System;

namespace GitOneClickSimpleCheckIn
{
  public class OrigemNaoDefinidaException: Exception
  {
    public OrigemNaoDefinidaException()
    {

    }

    public OrigemNaoDefinidaException(string message): base(message)
    {

    }

    public OrigemNaoDefinidaException(string message, Exception inner): base (message, inner)
    {

    }
  }
}
