using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Models
{
    public class MatrixBoard : IBoard
    {
        private readonly IList<int[,]> history;

        public MatrixBoard(int[,] matrix)
        {
            history = new List<int[,]> { matrix };
        }

        public int Get(Point point)
        {
            return history.Last()[point.Y, point.X];
        }

        public void Put(Point point, int value)
        {
            var clone = history.Last().Clone() as int[,];
            clone[point.Y, point.X] = value;
            history.Add(clone);
        }

        public string Print()
        {
            var sb = new StringBuilder();

            var matrix = history.Last();
            var height = matrix.GetLength(0);
            var width = matrix.GetLength(1);

            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    sb.Append(matrix[y, x]);

                    if (x == width - 1)
                    {
                        sb.Append('\n');
                    }
                }
            }

            return sb.ToString();
        }
    }
}