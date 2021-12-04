using System.Diagnostics;

namespace GitOneClickSimpleCheckIn
{
  public class CMDWindows : ICommandLineInterface
  {
    private Process cmd;
    public CMDWindows()
    {
      cmd = new Process();
      cmd.StartInfo.FileName = "cmd.exe";
      cmd.StartInfo.WorkingDirectory = @"C:\";
      cmd.StartInfo.RedirectStandardInput = true;
      cmd.StartInfo.RedirectStandardOutput = true;
      cmd.StartInfo.CreateNoWindow = true;
      cmd.StartInfo.UseShellExecute = false;
    } 

    public string EscreverNoCmd(string path, string command)
    {
      cmd.Start();
      cmd.StandardInput.WriteLine($@"cd {path}");
      cmd.StandardInput.WriteLine(command);
      cmd.StandardInput.Flush();
      cmd.StandardInput.Close();
      return RetornoCmd();
    }

    public string RetornoCmd() {
      return cmd.StandardOutput.ReadToEnd();
    }

    public void Finalizar() {
      cmd.WaitForExit();
    }
  }
}
