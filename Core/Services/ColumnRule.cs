using System.Linq;
using Core.Models;

namespace Core.Services
{
    public class ColumnRule : IBoardRule
    {
        public bool Test(IBoard board, Point point, int value)
        {
            var row = Enumerable.Range(0, 9).Select(_ =>
            {
                return board.Get(new Point(point.X, _));
            });

            return !row.Any(_ => _ == value);
        }
    }
}