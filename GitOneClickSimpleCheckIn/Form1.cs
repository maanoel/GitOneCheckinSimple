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

    private void DispararAcaoCMD(string gitProjectPath, string allCommandsForSimpleCheckIn)
    {
      txtGitReturn.Text = cmd.EscreverNoCmd(gitProjectPath, allCommandsForSimpleCheckIn);
    }

    private void btCheckIn_Click(object sender, EventArgs e)
    {
      try
      {
        validadorEntrada.CamposCheckInValidados();

        string gitProjectPath = txtPath.Text;
        string allCommandsForSimpleCheckIn = ComandosGit.Commit(txtDescription.Text);

        DispararAcaoCMD(gitProjectPath, allCommandsForSimpleCheckIn);
      }
      catch(Exception ex)
      {
        MessageBox.Show(ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
      }
    }

    private void btStatus_Click(object sender, EventArgs e)
    {
      try
      {
        validadorEntrada.PathDoGitFoiDefinido();

        string gitProjectPath = txtPath.Text;
        string allCommandsForSimpleCheckIn = ComandosGit.Status();

        DispararAcaoCMD(gitProjectPath, allCommandsForSimpleCheckIn);
      }
      catch(Exception ex)
      {
        MessageBox.Show(ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
      }
    }

    private void button2_Click(object sender, EventArgs e)
    {
      try
      {
        validadorEntrada.CamposFirstCommitValidados();

        string gitProjectPath = txtPath.Text;
        string allCommandsForSimpleCheckIn = ComandosGit.PrimeiroCommit(txtOrigin.Text);

        DispararAcaoCMD(gitProjectPath, allCommandsForSimpleCheckIn);
      }
      catch(Exception ex)
      {
        MessageBox.Show(ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
      }
    }

    private void button3_Click(object sender, EventArgs e)
    {
      try
      {
        if(validadorEntrada.ConfirmaRollback()) return;
        validadorEntrada.PathDoGitFoiDefinido();

        string gitProjectPath = txtPath.Text;
        string allCommandsForSimpleCheckIn = ComandosGit.Rollback();

        DispararAcaoCMD(gitProjectPath, allCommandsForSimpleCheckIn);

      }
      catch(Exception ex)
      {
        MessageBox.Show(ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
      }
    }
  }
}
