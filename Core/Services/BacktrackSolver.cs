using System.Collections.Generic;
using System.Linq;
using Core.Models;

namespace Core.Services
{
    public class BacktrackSolver : ISolver
    {
        public IList<IBoard> Solve(IBoard board, IEnumerable<IBoardRule> rules)
        {
            var history = new List<IBoard> { board };
            SolveRecursive(history, rules);
            return history;
        }

        public bool SolveRecursive(IList<IBoard> boards, IEnumerable<IBoardRule> rules)
        {
            foreach (var x in Enumerable.Range(0, 9))
            {
                foreach (var y in Enumerable.Range(0, 9))
                {
                    var point = new Point(x, y);
                    var currentValue = boards.Last().Get(point);

                    if (currentValue == 0)
                    {
                        foreach (var newValue in Enumerable.Range(1, 9))
                        {
                            if (IsPossible(boards.Last(), rules, point, newValue))
                            {
                                boards.Add(boards.Last().Put(point, newValue));

                                if (SolveRecursive(boards, rules))
                                {
                                    return true;
                                }

                                boards.Add(boards.Last().Put(point, 0));
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