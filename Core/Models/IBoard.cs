namespace Core.Models
{
    public interface IBoard
    {
        IBoard Put(Point point, int value);
        int Get(Point point);
        string Print();
    }
}