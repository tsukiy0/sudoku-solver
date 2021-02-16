using System;
using System.Text;

namespace Core.Models
{
    public class MatrixBoard : IBoard
    {
        private readonly int[,] matrix;

        public MatrixBoard(int[,] matrix)
        {
            this.matrix = matrix;
        }

        public int Get(Point point)
        {
            return matrix[point.Y, point.X];
        }

        public IBoard Put(Point point, int value)
        {
            var clone = matrix.Clone() as int[,];
            clone[point.Y, point.X] = value;
            return new MatrixBoard(clone);
        }

        public string Print()
        {
            var sb = new StringBuilder();

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