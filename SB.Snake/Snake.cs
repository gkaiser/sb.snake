using System;
using System.Linq;
using System.Drawing;
using System.Collections.Generic;

namespace SB.Snake
{
  internal class Snake
  {
    internal readonly Size BoardSize;
    internal int X;
    internal int Y;
    internal int SpeedHoriz;
    internal int SpeedVert;
    internal const int WIDTH = 10;
    internal const int HEIGHT = 10;
    internal int Length = 1;

    internal Snake(Size boardSize)
    {
      this.BoardSize = boardSize;

      this.X = (this.BoardSize.Width / 2) - (Snake.WIDTH / 2);
      this.Y = (this.BoardSize.Height / 2) - (Snake.HEIGHT / 2);
    }

    internal List<Point> History { get; } = new List<Point>();

    internal bool IsMoving => this.SpeedHoriz != 0 || this.SpeedVert != 0;

    internal bool IsEatingSelf => this.IsMoving && this.History.Any(p => p.X == this.X && p.Y == this.Y);

    internal void UpdateLocation()
    {
      if (!this.IsMoving)
        return;

      if (this.History.Count == 0 || this.History.Last().X != this.X || this.History.Last().Y != this.Y)
      {
        this.History.Add(new Point(this.X, this.Y));
        this.History.RemoveRange(0, this.History.Count - this.Length);
      }

      this.X = this.X + (Snake.WIDTH * this.SpeedHoriz);
      this.Y = this.Y + (Snake.HEIGHT * this.SpeedVert);
    }

    internal bool IsEating(List<Food> food)
    {
      if (!this.IsMoving)
        return false;

      var isEating = food.Any(f => f.X == this.X && f.Y == this.Y);

      return isEating;
    }


  }
}
