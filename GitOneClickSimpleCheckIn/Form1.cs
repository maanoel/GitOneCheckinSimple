using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace GitOneClickSimpleCheckIn
{
  public partial class Form1 : Form
  {
    private ICommandLineInterface cmd;
    private ValidadorEntrada validadorEntrada;

    public Form1()
    {
      InitializeComponent();
      cmd = new CMDWindows();
      validadorEntrada = new ValidadorEntrada(txtPath, txtDescription, txtOrigin);
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
      if(!validadorEntrada.CamposCheckInValidados()) return;
      string gitProjectPath = txtPath.Text;
      string allCommandsForSimpleCheckIn = ComandosGit.Commit(txtDescription.Text);

      DispararAcaoCMD(gitProjectPath, allCommandsForSimpleCheckIn);
    }

    private void btStatus_Click(object sender, EventArgs e)
    {
      if(!validadorEntrada.PathDoGitFoiDefinido()) return;
      string gitProjectPath = txtPath.Text;
      string allCommandsForSimpleCheckIn = ComandosGit.Status();

      DispararAcaoCMD(gitProjectPath, allCommandsForSimpleCheckIn);
    }

    private void button2_Click(object sender, EventArgs e)
    {
      if(!validadorEntrada.CamposFirstCommitValidados()) return;

      string gitProjectPath = txtPath.Text;
      string allCommandsForSimpleCheckIn = ComandosGit.PrimeiroCommit(txtOrigin.Text);

      DispararAcaoCMD(gitProjectPath, allCommandsForSimpleCheckIn);
    }

    private void DispararAcaoCMD(string gitProjectPath, string allCommandsForSimpleCheckIn)
    {
      txtGitReturn.Text = cmd.EscreverNoCmd(gitProjectPath, allCommandsForSimpleCheckIn);
    }

    private void button3_Click(object sender, EventArgs e)
    {
      if(!validadorEntrada.PathDoGitFoiDefinido() || !validadorEntrada.ConfirmaRollback()) return;

      string gitProjectPath = txtPath.Text;
      string allCommandsForSimpleCheckIn = ComandosGit.Rollback();

      DispararAcaoCMD(gitProjectPath, allCommandsForSimpleCheckIn);
    }
  }
}
