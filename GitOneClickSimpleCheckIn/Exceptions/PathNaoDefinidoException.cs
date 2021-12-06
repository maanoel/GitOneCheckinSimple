using System;

namespace GitOneClickSimpleCheckIn
{
  public class PathNaoDefinidoException : Exception
  {
    public PathNaoDefinidoException()
    {

    }

    public PathNaoDefinidoException(string message): base(message)
    {

    }

    public PathNaoDefinidoException(string message, Exception inner): base (message, inner)
    {

    }
  }
}
