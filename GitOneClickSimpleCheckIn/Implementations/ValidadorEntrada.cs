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

    public void PathDoGitFoiDefinido()
    {
      if(String.IsNullOrEmpty(txtPath.Text))
        throw new PathNaoDefinidoException("You need to set path of the git folder.");
    }

    private void DescricaoCommitFoiDefinida()
    {
      if(String.IsNullOrEmpty(txtDescription.Text))
        throw new DescricaoCommitNaoDefinidaException("You need to set a message of the git commit.");
    }

    private void OriginFoiDefinida()
    {
      if(String.IsNullOrEmpty(txtOrigin.Text))
        throw new OrigemNaoDefinidaException("You need to set origin of the git folder.");
    }

    public void CamposCheckInValidados()
    {
      PathDoGitFoiDefinido();
      DescricaoCommitFoiDefinida();
    }

    public void CamposFirstCommitValidados()
    {
      OriginFoiDefinida();
      PathDoGitFoiDefinido();
    }

    public bool ConfirmaRollback()
    {
      var retorno = MessageBox.Show("Are you sure?", "Really?",
       MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

      return retorno == DialogResult.Yes;
    }
  }
}
