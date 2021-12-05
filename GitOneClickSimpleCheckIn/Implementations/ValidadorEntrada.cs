using System;
using System.Windows.Forms;

namespace GitOneClickSimpleCheckIn
{
  public class ValidadorEntrada
  {
    private TextBox txtPath;
    private TextBox txtDescription;
    private TextBox txtOrigin;

    public ValidadorEntrada(TextBox txtPath, TextBox txtDescription, TextBox txtOrigin)
    {
      this.txtPath = txtPath;
      this.txtDescription = txtDescription;
      this.txtOrigin = txtOrigin;
    }

    public bool PathDoGitFoiDefinido()
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

    private  bool OriginFoiDefinida()
    {
      if(String.IsNullOrEmpty(txtOrigin.Text))
      {
        MessageBox.Show("You need to set origin of the git folder.", "Set a origin",
        MessageBoxButtons.OK, MessageBoxIcon.Stop);

        return false;
      }

      return true;
    }

    public bool CamposCheckInValidados() {
      return(PathDoGitFoiDefinido() && DescricaoCommitNaoFoiDefinida());
    }

    public bool CamposFirstCommitValidados() 
    {
      return PathDoGitFoiDefinido() && OriginFoiDefinida();
    }
  }
}
