using Core.Models;

namespace Core.Services
{
    public interface IBoardRule
    {
        bool Test(IBoard board, Point point);
    }
}