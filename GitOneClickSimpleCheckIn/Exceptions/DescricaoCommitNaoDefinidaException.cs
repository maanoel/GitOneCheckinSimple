using System;

namespace GitOneClickSimpleCheckIn
{
  public class DescricaoCommitNaoDefinidaException : Exception
  {
    public DescricaoCommitNaoDefinidaException()
    {

    }

    public DescricaoCommitNaoDefinidaException(string message): base(message)
    {

    }

    public DescricaoCommitNaoDefinidaException(string message, Exception inner): base (message, inner)
    {

    }
  }
}
