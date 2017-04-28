using System;
using System.Linq;
using System.Drawing;
using System.Collections.Generic;

namespace SB.Snake
{
  internal class Food
  {
    internal readonly Size BoardSize;
    internal int X;
    internal int Y;

    internal Food(Size boardSize)
    {
      this.BoardSize = boardSize;

      var cols = boardSize.Width / 10;
      var rows = boardSize.Height / 10;

      this.X = Program.RndGen.Next(cols) * 10;
      this.Y = Program.RndGen.Next(rows) * 10;
    }

    internal static List<Food> GenerateFoodPieces(int count, Size boardSize)
    {
      var food = new List<Food>();

      for (int i = 0; i < count; i++)
      {
        food.Add(new Food(boardSize));
      }

      return food;
    }

  }
}
