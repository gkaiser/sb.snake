using System;
using System.Linq;
using System.Drawing;
using System.Collections.Generic;

namespace SB.Snake
{
  internal class Snake
  {
    internal int X;
    internal int Y;
    internal int Length = 1;
    internal int SpeedHoriz = 0;
    internal int SpeedVert = 0;
    internal readonly Size BoardSize;
    internal const int WIDTH = 20;
    internal const int HEIGHT = 20;

    internal Snake(Size boardSize)
    {
      this.BoardSize = boardSize;

      var cols = this.BoardSize.Width / Snake.WIDTH;
      var rows = this.BoardSize.Height / Snake.HEIGHT;

      this.X = (cols / 2) * Snake.WIDTH;
      this.Y = (rows / 2) * Snake.HEIGHT;
    }

    internal List<Point> History { get; } = new List<Point>();

    internal bool IsMoving => this.SpeedHoriz != 0 || this.SpeedVert != 0;

    internal bool IsEatingSelf => this.IsMoving && this.History.Any(p => p.X == this.X && p.Y == this.Y);

    internal bool HasGoneOffTheReservation =>
      this.IsMoving && (
      this.X == 0 && this.SpeedHoriz == -1 ||
      this.Y == 0 && this.SpeedVert == -1 ||
      this.X + Snake.WIDTH >= this.BoardSize.Width && this.SpeedHoriz == 1 ||
      this.Y + Snake.HEIGHT >= this.BoardSize.Height && this.SpeedVert == 1);

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
