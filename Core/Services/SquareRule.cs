using System;
using System.Linq;
using Core.Models;

namespace Core.Services
{
    public class SquareRule : IBoardRule
    {
        public bool Test(IBoard board, Point point, int value)
        {
            var x0 = (int)Math.Floor((decimal)point.X / 3) * 3;
            var y0 = (int)Math.Floor((decimal)point.Y / 3) * 3;

            var square = Enumerable.Range(0, 3).SelectMany(x =>
            {
                return Enumerable.Range(0, 3).Select(y =>
                {
                    return board.Get(new Point(x0 + x, y0 + y));
                });
            });

            return !square.Any(_ => _ == value);
        }
    }
}