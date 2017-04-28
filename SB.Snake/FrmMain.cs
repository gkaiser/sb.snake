using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SB.Snake
{
  public partial class FrmMain : Form
  {
    private Timer RedrawTimer;
    private Snake Snake;
    private int FramesPerSec = 10;
    private List<Food> FoodPieces;

    public FrmMain()
    {
      InitializeComponent();

      this.FormBorderStyle = FormBorderStyle.None;
      this.ClientSize = new Size(610, 610);

      this.RedrawTimer = new Timer();
      this.RedrawTimer.Interval = (int)((1m / this.FramesPerSec) * 1000m);
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
      for (int i = 0; i < this.Snake.Length - 1; i++)
        gfx.FillRectangle(Brushes.White, this.Snake.History[i].X, this.Snake.History[i].Y, Snake.WIDTH, Snake.HEIGHT);

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
      if (e.KeyCode == Keys.Up)
      {
        this.Snake.SpeedHoriz = 0;
        this.Snake.SpeedVert = -1;
      }
      else if (e.KeyCode == Keys.Down)
      {
        this.Snake.SpeedHoriz = 0;
        this.Snake.SpeedVert = 1;
      }
      else if (e.KeyCode == Keys.Left)
      {
        this.Snake.SpeedHoriz = -1;
        this.Snake.SpeedVert = 0;
      }
      else if (e.KeyCode == Keys.Right)
      {
        this.Snake.SpeedHoriz = 1;
        this.Snake.SpeedVert = 0;
      }
    }

    private void ctxMain_miStart_Click(object sender, EventArgs e)
    {

    }

    private void ctxMain_miReset_Click(object sender, EventArgs e)
    {
      this.Snake = new Snake(this.Size);
      this.FoodPieces = Food.GenerateFoodPieces(3, this.Size);
    }

    private void ctxMain_miQuit_Click(object sender, EventArgs e)
    {
      this.Close();
    }


  }
}
