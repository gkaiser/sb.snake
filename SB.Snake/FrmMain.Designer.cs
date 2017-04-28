namespace SB.Snake
{
  partial class FrmMain
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
      this.ctxMain = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.ctxMain_miStart = new System.Windows.Forms.ToolStripMenuItem();
      this.ctxMain_miReset = new System.Windows.Forms.ToolStripMenuItem();
      this.ctxMain_sepMain = new System.Windows.Forms.ToolStripSeparator();
      this.ctxMain_miQuit = new System.Windows.Forms.ToolStripMenuItem();
      this.ctxMain.SuspendLayout();
      this.SuspendLayout();
      // 
      // ctxMain
      // 
      this.ctxMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxMain_miStart,
            this.ctxMain_miReset,
            this.ctxMain_sepMain,
            this.ctxMain_miQuit});
      this.ctxMain.Name = "ctxMain";
      this.ctxMain.Size = new System.Drawing.Size(103, 76);
      // 
      // ctxMain_miStart
      // 
      this.ctxMain_miStart.Name = "ctxMain_miStart";
      this.ctxMain_miStart.Size = new System.Drawing.Size(102, 22);
      this.ctxMain_miStart.Text = "Start";
      this.ctxMain_miStart.Click += new System.EventHandler(this.ctxMain_miStart_Click);
      // 
      // ctxMain_miReset
      // 
      this.ctxMain_miReset.Name = "ctxMain_miReset";
      this.ctxMain_miReset.Size = new System.Drawing.Size(102, 22);
      this.ctxMain_miReset.Text = "Reset";
      this.ctxMain_miReset.Click += new System.EventHandler(this.ctxMain_miReset_Click);
      // 
      // ctxMain_sepMain
      // 
      this.ctxMain_sepMain.Name = "ctxMain_sepMain";
      this.ctxMain_sepMain.Size = new System.Drawing.Size(99, 6);
      // 
      // ctxMain_miQuit
      // 
      this.ctxMain_miQuit.Name = "ctxMain_miQuit";
      this.ctxMain_miQuit.Size = new System.Drawing.Size(102, 22);
      this.ctxMain_miQuit.Text = "Quit";
      this.ctxMain_miQuit.Click += new System.EventHandler(this.ctxMain_miQuit_Click);
      // 
      // FrmMain
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(284, 261);
      this.ContextMenuStrip = this.ctxMain;
      this.DoubleBuffered = true;
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.KeyPreview = true;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "FrmMain";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "SB.Snake";
      this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmMain_KeyDown);
      this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmMain_MouseDown);
      this.ctxMain.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ContextMenuStrip ctxMain;
    private System.Windows.Forms.ToolStripMenuItem ctxMain_miStart;
    private System.Windows.Forms.ToolStripMenuItem ctxMain_miReset;
    private System.Windows.Forms.ToolStripSeparator ctxMain_sepMain;
    private System.Windows.Forms.ToolStripMenuItem ctxMain_miQuit;
  }
}

