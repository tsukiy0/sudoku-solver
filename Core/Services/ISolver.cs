using Core.Models;

namespace Core.Services
{
    public interface ISolver
    {
        IBoard Solve(IBoard board, IBoardRule[] rules);
    }
}