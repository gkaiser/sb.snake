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

      var cols = boardSize.Width / Snake.WIDTH;
      var rows = boardSize.Height / Snake.HEIGHT;

      this.X = Program.RndGen.Next(cols) * Snake.WIDTH;
      this.Y = Program.RndGen.Next(rows) * Snake.HEIGHT;
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
