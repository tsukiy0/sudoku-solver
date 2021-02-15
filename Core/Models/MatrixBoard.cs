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
            throw new System.NotImplementedException();
        }

        public void Put(Point point, int value)
        {
            throw new System.NotImplementedException();
        }

        public string Print()
        {
            throw new System.NotImplementedException();
        }
    }
}