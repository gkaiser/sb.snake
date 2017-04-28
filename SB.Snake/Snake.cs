using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    private List<Point> InternalHistory = new List<Point>();

    internal Snake(Size boardSize)
    {
      this.BoardSize = boardSize;

      this.X = (this.BoardSize.Width / 2) - (Snake.WIDTH / 2);
      this.Y = (this.BoardSize.Height / 2) - (Snake.HEIGHT / 2);
    }

    internal List<Point> History
    {
      get { return this.InternalHistory; }
    }

    internal void UpdateLocation()
    {
      if (this.InternalHistory.Last().X != this.X || this.InternalHistory.Last().Y != this.Y)
      {
        this.InternalHistory.Add(new Point(this.X, this.Y));
        this.InternalHistory.Reverse();
      }

      System.Diagnostics.Debug.WriteLine($"Snake is {this.Length} blocks long, with {this.History.Count} historical locations.");

      this.X = this.X + (Snake.WIDTH * this.SpeedHoriz);
      this.Y = this.Y + (Snake.HEIGHT * this.SpeedVert);
    }

    internal bool IsEating(List<Food> food)
    {
      var isEating = food.Any(f => f.X == this.X && f.Y == this.Y);

      if (isEating)
        Console.WriteLine($"is eating @ {{{this.X}, {this.Y}}}");

      return isEating;
    }

  }
}
