
namespace GitOneClickSimpleCheckIn
{
  partial class Form1
  {
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if(disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.btCheckIn = new System.Windows.Forms.Button();
      this.txtDescription = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.txtPath = new System.Windows.Forms.TextBox();
      this.txtGitReturn = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.button1 = new System.Windows.Forms.Button();
      this.button2 = new System.Windows.Forms.Button();
      this.label4 = new System.Windows.Forms.Label();
      this.txtOrigin = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // btCheckIn
      // 
      this.btCheckIn.Location = new System.Drawing.Point(13, 413);
      this.btCheckIn.Name = "btCheckIn";
      this.btCheckIn.Size = new System.Drawing.Size(115, 23);
      this.btCheckIn.TabIndex = 0;
      this.btCheckIn.Text = "Check In";
      this.btCheckIn.UseVisualStyleBackColor = true;
      this.btCheckIn.Click += new System.EventHandler(this.btCheckIn_Click);
      // 
      // txtDescription
      // 
      this.txtDescription.Location = new System.Drawing.Point(133, 43);
      this.txtDescription.Name = "txtDescription";
      this.txtDescription.Size = new System.Drawing.Size(997, 23);
      this.txtDescription.TabIndex = 1;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(26, 46);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(102, 15);
      this.label1.TabIndex = 2;
      this.label1.Text = "Check in Message";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(61, 18);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(67, 15);
      this.label2.TabIndex = 4;
      this.label2.Text = "Folder Path";
      // 
      // txtPath
      // 
      this.txtPath.Location = new System.Drawing.Point(133, 15);
      this.txtPath.Name = "txtPath";
      this.txtPath.Size = new System.Drawing.Size(997, 23);
      this.txtPath.TabIndex = 3;
      // 
      // txtGitReturn
      // 
      this.txtGitReturn.Enabled = false;
      this.txtGitReturn.Location = new System.Drawing.Point(12, 139);
      this.txtGitReturn.Multiline = true;
      this.txtGitReturn.Name = "txtGitReturn";
      this.txtGitReturn.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
      this.txtGitReturn.Size = new System.Drawing.Size(1118, 268);
      this.txtGitReturn.TabIndex = 5;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(13, 112);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(57, 15);
      this.label3.TabIndex = 6;
      this.label3.Text = "Git return";
      this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(134, 413);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(115, 23);
      this.button1.TabIndex = 7;
      this.button1.Text = "Git Status";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.btStatus_Click);
      // 
      // button2
      // 
      this.button2.Location = new System.Drawing.Point(255, 413);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(115, 23);
      this.button2.TabIndex = 8;
      this.button2.Text = "First commit";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new System.EventHandler(this.button2_Click);
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(12, 72);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(114, 15);
      this.label4.TabIndex = 10;
      this.label4.Text = "First Check in Origin";
      // 
      // txtOrigin
      // 
      this.txtOrigin.Location = new System.Drawing.Point(133, 69);
      this.txtOrigin.Name = "txtOrigin";
      this.txtOrigin.Size = new System.Drawing.Size(998, 23);
      this.txtOrigin.TabIndex = 9;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1146, 441);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.txtOrigin);
      this.Controls.Add(this.button2);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.txtGitReturn);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.txtPath);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.txtDescription);
      this.Controls.Add(this.btCheckIn);
      this.Name = "Form1";
      this.Text = "Git One Click Simple Check In";
      this.Load += new System.EventHandler(this.Form1_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btCheckIn;
    private System.Windows.Forms.TextBox txtDescription;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox txtPath;
    private System.Windows.Forms.TextBox txtGitReturn;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox txtOrigin;
  }
}

