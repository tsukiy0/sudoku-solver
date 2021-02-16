using System.Collections.Generic;
using Core.Models;

namespace Core.Services
{
    public interface ISolver
    {
        IBoard Solve(IBoard board, IEnumerable<IBoardRule> rules);
    }
}