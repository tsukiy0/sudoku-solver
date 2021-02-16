using System.Collections.Generic;
using System.Linq;
using Core.Models;

namespace Core.Services
{
    public class BacktrackSolver : ISolver
    {
        public IBoard Solve(IBoard board, IEnumerable<IBoardRule> rules)
        {
            SolveRecursive(board, rules);
            return board;
        }

        public bool SolveRecursive(IBoard board, IEnumerable<IBoardRule> rules)
        {
            foreach (var x in Enumerable.Range(0, 9))
            {
                foreach (var y in Enumerable.Range(0, 9))
                {
                    var point = new Point(x, y);
                    var currentValue = board.Get(point);

                    if (currentValue == 0)
                    {
                        foreach (var newValue in Enumerable.Range(1, 9))
                        {
                            if (IsPossible(board, rules, point, newValue))
                            {
                                board.Put(point, newValue);
                                var b = board.Print();

                                if (SolveRecursive(board, rules))
                                {
                                    return true;
                                }

                                board.Put(point, 0);
                            }
                        }
                        return false;
                    }
                }
            }

            return true;
        }

        private static bool IsPossible(IBoard board, IEnumerable<IBoardRule> rules, Point point, int value)
        {
            var result = rules.Select(_ => _.Test(board, point, value));

            return result.All(_ => _);
        }
    }
}