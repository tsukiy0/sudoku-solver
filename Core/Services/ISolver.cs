using System.Collections.Generic;
using Core.Models;

namespace Core.Services
{
    public interface ISolver
    {
        IList<IBoard> Solve(IBoard board, IEnumerable<IBoardRule> rules);
    }
}