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
    private const int FRAMES_PER_SEC = 6;//10;
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
        this.DrawFoodBlock(i, gfx);

      this.DrawSnakeHeadBlock(gfx);
      for (int i = (this.Snake.History.Count - 1); i > (this.Snake.History.Count - this.Snake.Length); i--)
        this.DrawSnakeTailBlock(i, gfx);

      if (this.Snake.IsEatingSelf || this.Snake.HasGoneOffTheReservation)
      {
        this.RedrawTimer.Stop();
        this.Snake.SpeedHoriz = 0;
        this.Snake.SpeedVert = 0;

        var goFont = new Font("Sans Serif", 14f, FontStyle.Bold);
        var goString = $"GAME OVER - YOUR SNAKE WAS {this.Snake.Length} BLOCKS LONG";
        var goWidth = (int)gfx.MeasureString(goString, goFont).Width;
        var resetString = "PRESS [SPACE] TO RESET";
        var resetWidth = (int)gfx.MeasureString(resetString, goFont).Width;

        gfx.DrawString(goString, goFont, Brushes.Yellow, (this.ClientSize.Width / 2) - (goWidth / 2), this.ClientSize.Height / 2);
        gfx.DrawString(resetString, goFont, Brushes.Yellow, (this.ClientSize.Width / 2) - (resetWidth / 2), (this.ClientSize.Height / 2) + 20);
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
      if (e.KeyCode == Keys.Space)
        this.ctxMain_miReset_Click(sender, e);
      else if (e.KeyCode == Keys.Up && this.Snake.SpeedVert == 0)
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
      this.FoodPieces = Food.GenerateFoodPieces(7, this.Size);
      this.RedrawTimer.Start();
    }

    private void ctxMain_miQuit_Click(object sender, EventArgs e)
    {
      this.Close();
    }


    private void DrawFoodBlock(int i , Graphics gfx)
    {
      gfx.FillRectangle(Brushes.Purple, this.FoodPieces[i].X, this.FoodPieces[i].Y, Snake.WIDTH, Snake.HEIGHT);
      gfx.FillEllipse(Brushes.SpringGreen, this.FoodPieces[i].X + 1, this.FoodPieces[i].Y + 1, Snake.WIDTH - 3, Snake.HEIGHT - 3);
    }

    private void DrawSnakeHeadBlock(Graphics gfx)
    {
      gfx.FillRectangle(Brushes.LightGray, this.Snake.X, this.Snake.Y, Snake.WIDTH, Snake.HEIGHT);
      gfx.FillRectangle(Brushes.White, this.Snake.X + 1, this.Snake.Y + 1, Snake.WIDTH - 2, Snake.HEIGHT - 2);
    }

    private void DrawSnakeTailBlock(int i, Graphics gfx)
    {
      gfx.FillRectangle(Brushes.LightGray, this.Snake.History[i].X, this.Snake.History[i].Y, Snake.WIDTH, Snake.HEIGHT);
      gfx.FillRectangle(Brushes.White, this.Snake.History[i].X + 1, this.Snake.History[i].Y + 1, Snake.WIDTH - 2, Snake.HEIGHT - 2);
    }

  }
}
