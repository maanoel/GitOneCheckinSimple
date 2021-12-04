using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace GitOneClickSimpleCheckIn
{
  public partial class Form1 : Form
  {
    private ICommandLineInterface cmd;
    public Form1()
    {
      InitializeComponent();
      cmd = new CMDWindows();
    }

    private void Form1_Load(object sender, EventArgs e)
    {

    }

    void Form_FormClosing(object sender, FormClosingEventArgs e)
    {
      cmd.Finalizar();
    }

    private void btCheckIn_Click(object sender, EventArgs e)
    {
      if(!PathDoGitFoiDefinido() || !DescricaoCommitNaoFoiDefinida()) return;
      string gitProjectPath = txtPath.Text;
      string allCommandsForSimpleCheckIn = GitCommands.Commit(txtDescription.Text);

      DispararAcaoCMD(gitProjectPath, allCommandsForSimpleCheckIn);
    }

    private void btStatus_Click(object sender, EventArgs e)
    {
      if(!PathDoGitFoiDefinido()) return;
      string gitProjectPath = txtPath.Text;
      string allCommandsForSimpleCheckIn = GitCommands.Status();

      DispararAcaoCMD(gitProjectPath, allCommandsForSimpleCheckIn);
    }

    private void button2_Click(object sender, EventArgs e)
    {
      if(!PathDoGitFoiDefinido() || !OriginFoiDefinida()) return;

      string gitProjectPath = txtPath.Text;
      string allCommandsForSimpleCheckIn = GitCommands.PrimeiroCommit(txtOrigin.Text);

      DispararAcaoCMD(gitProjectPath, allCommandsForSimpleCheckIn);
    }

    private void DispararAcaoCMD(string gitProjectPath, string allCommandsForSimpleCheckIn)
    {
      txtGitReturn.Text = cmd.EscreverNoCmd(gitProjectPath, allCommandsForSimpleCheckIn);
    }
     
    private bool PathDoGitFoiDefinido()
    {
      if(String.IsNullOrEmpty(txtPath.Text))
      {
        MessageBox.Show("You need to set path of the git folder.", "Set a path",
        MessageBoxButtons.OK, MessageBoxIcon.Stop);

        return false;
      }

      return true; 
    }

    private bool DescricaoCommitNaoFoiDefinida()
    {
      if(String.IsNullOrEmpty(txtDescription.Text))
      {
        MessageBox.Show("You need to set a message of the git commit.", "Set a message",
        MessageBoxButtons.OK, MessageBoxIcon.Stop);

        return false;
      }

      return true;
    }

    private bool OriginFoiDefinida()
    {
      if(String.IsNullOrEmpty(txtOrigin.Text))
      {
        MessageBox.Show("You need to set origin of the git folder.", "Set a origin",
        MessageBoxButtons.OK, MessageBoxIcon.Stop);

        return false;
      }

      return true;
    }
  }
}
