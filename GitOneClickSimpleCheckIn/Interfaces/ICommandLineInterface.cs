namespace GitOneClickSimpleCheckIn
{
  public interface ICommandLineInterface
  {
    string EscreverNoCmd(string path, string command);
    void Finalizar();
    string RetornoCmd();
  }
}