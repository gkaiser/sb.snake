using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace SB.Snake
{
  public partial class FrmMain : Form
  {
    private Timer RedrawTimer;
    private const int FRAMES_PER_SEC = 10;
    private Snake Snake;
    private List<Food> FoodPieces;

    public FrmMain()
    {
      InitializeComponent();

      this.FormBorderStyle = FormBorderStyle.None;
      this.ClientSize = new Size(610, 610);

      this.RedrawTimer = new Timer();
      this.RedrawTimer.Interval = (int)((1m / FrmMain.FRAMES_PER_SEC) * 1000m);
      this.RedrawTimer.Tick += (s, ea) => this.Invalidate();
      this.RedrawTimer.Start();

      this.ctxMain_miReset_Click(null, null);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      base.OnPaint(e);

      var gfx = e.Graphics;
      gfx.FillRectangle(Brushes.Black, this.ClientRectangle);

      for (int i = 0; i < this.FoodPieces.Count; i++)
        gfx.FillRectangle(Brushes.Purple, this.FoodPieces[i].X, this.FoodPieces[i].Y, Snake.WIDTH, Snake.HEIGHT);

      gfx.FillRectangle(Brushes.White, this.Snake.X, this.Snake.Y, Snake.WIDTH, Snake.HEIGHT);
      for (int i = (this.Snake.History.Count - 1); i > (this.Snake.History.Count - this.Snake.Length); i--)
        gfx.FillRectangle(Brushes.White, this.Snake.History[i].X, this.Snake.History[i].Y, Snake.WIDTH, Snake.HEIGHT);

      // there's a bug here somewhere
      // if the snake moves along itself (side-by-side) then
      // it's being interpreted as eating itself. not sure 
      // why at the moment...
      if (this.Snake.IsEatingSelf)
      {
        this.RedrawTimer.Stop();
        this.Snake.SpeedHoriz = 0;
        this.Snake.SpeedVert = 0;

        var goFont = new Font("Sans Serif", 14f, FontStyle.Bold);
        var goString = $"GAME OVER - YOUR SNAKE WAS {this.Snake.Length} BLOCKS LONG";
        var stringWidth = (int)gfx.MeasureString(goString, goFont).Width;

        gfx.DrawString(goString, goFont, Brushes.Yellow, (this.ClientSize.Width / 2) - (stringWidth / 2), 300);
      }
      if (this.Snake.IsEating(this.FoodPieces))
      {
        this.FoodPieces.Remove(this.FoodPieces.First(f => f.X == this.Snake.X && f.Y == this.Snake.Y));
        this.FoodPieces.Add(new Food(this.Size));

        this.Snake.Length++;
      }

      this.Snake.UpdateLocation();
    }

    private void FrmMain_MouseDown(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Left)
      {
        Win32.ReleaseCapture();
        Win32.SendMessage(this.Handle, Win32.WM_NCLBUTTONDOWN, Win32.HT_CAPTION, 0);
      }
    }

    private void FrmMain_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Up && this.Snake.SpeedVert == 0)
      {
        this.Snake.SpeedHoriz = 0;
        this.Snake.SpeedVert = -1;
      }
      else if (e.KeyCode == Keys.Down && this.Snake.SpeedVert == 0)
      {
        this.Snake.SpeedHoriz = 0;
        this.Snake.SpeedVert = 1;
      }
      else if (e.KeyCode == Keys.Left && this.Snake.SpeedHoriz == 0)
      {
        this.Snake.SpeedHoriz = -1;
        this.Snake.SpeedVert = 0;
      }
      else if (e.KeyCode == Keys.Right && this.Snake.SpeedHoriz == 0)
      {
        this.Snake.SpeedHoriz = 1;
        this.Snake.SpeedVert = 0;
      }
    }

    private void ctxMain_miReset_Click(object sender, EventArgs e)
    {
      this.RedrawTimer.Stop();
      this.Snake = new Snake(this.Size);
      this.FoodPieces = Food.GenerateFoodPieces(3, this.Size);
      this.RedrawTimer.Start();
    }

    private void ctxMain_miQuit_Click(object sender, EventArgs e)
    {
      this.Close();
    }

  }
}
