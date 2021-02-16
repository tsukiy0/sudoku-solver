namespace Core.Models
{
    public interface IBoard
    {
        void Put(Point point, int value);
        int Get(Point point);
        string Print();
    }
}