using Core.Models;
using Core.Services;
using Xunit;
using System.Collections.Generic;
using FluentAssertions;

namespace Core.Tests.Services
{
    public class BacktrackSolverTests
    {
        public ISolver Setup()
        {
            return new BacktrackSolver();
        }

        // https://dingo.sbs.arizona.edu/~sandiway/sudoku/examples.html
        // Arizona Daily Wildcat: Tuesday, Jan 17th 2006
        [Fact]
        public void Solve1()
        {
            var board = new MatrixBoard(new int[9, 9]
            {
                { 0, 0, 0, 2, 6, 0, 7, 0, 1 },
                { 6, 8, 0, 0, 7, 0, 0, 9, 0 },
                { 1, 9, 0, 0, 0, 4, 5, 0, 0 },
                { 8, 2, 0, 1, 0, 0, 0, 4, 0 },
                { 0, 0, 4, 6, 0, 2, 9, 0, 0 },
                { 0, 5, 0, 0, 0, 3, 0, 2, 8 },
                { 0, 0, 9, 3, 0, 0, 0, 7, 4 },
                { 0, 4, 0, 0, 5, 0, 0, 3, 6 },
                { 7, 0, 3, 0, 1, 8, 0, 0, 0 }
            });

            var solution = new MatrixBoard(new int[9, 9]
            {
                { 4, 3, 5, 2, 6, 9, 7, 8, 1 },
                { 6, 8, 2, 5, 7, 1, 4, 9, 3 },
                { 1, 9, 7, 8, 3, 4, 5, 6, 2 },
                { 8, 2, 6, 1, 9, 5, 3, 4, 7 },
                { 3, 7, 4, 6, 8, 2, 9, 1, 5 },
                { 9, 5, 1, 7, 4, 3, 6, 2, 8 },
                { 5, 1, 9, 3, 2, 6, 8, 7, 4 },
                { 2, 4, 8, 9, 5, 7, 1, 3, 6 },
                { 7, 6, 3, 4, 1, 8, 2, 5, 9 }
            });

            var sut = Setup();

            var actual = sut.Solve(board, new List<IBoardRule>{
                new RowRule(),
                new ColumnRule(),
                new SquareRule()
            });

            actual.Print().Should().Be(solution.Print());
        }

        // https://dingo.sbs.arizona.edu/~sandiway/sudoku/examples.html
        // Challenge 1 from Sudoku Solver by Logic
        [Fact]
        public void Solve2()
        {
            var board = new MatrixBoard(new int[9, 9]
            {
                { 0, 2, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 6, 0, 0, 0, 0, 3 },
                { 0, 7, 4, 0, 8, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 3, 0, 0, 2 },
                { 0, 8, 0, 0, 4, 0, 0, 1, 0 },
                { 6, 0, 0, 5, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 1, 0, 7, 8, 0 },
                { 5, 0, 0, 0, 0, 9, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 4, 0 }
            });

            var solution = new MatrixBoard(new int[9, 9]
            {
                { 1, 2, 6, 4, 3, 7, 9, 5, 8 },
                { 8, 9, 5, 6, 2, 1, 4, 7, 3 },
                { 3, 7, 4, 9, 8, 5, 1, 2, 6 },
                { 4, 5, 7, 1, 9, 3, 8, 6, 2 },
                { 9, 8, 3, 2, 4, 6, 5, 1, 7 },
                { 6, 1, 2, 5, 7, 8, 3, 9, 4 },
                { 2, 6, 9, 3, 1, 4, 7, 8, 5 },
                { 5, 4, 8, 7, 6, 9, 2, 3, 1 },
                { 7, 3, 1, 8, 5, 2, 6, 4, 9 }
            });

            var sut = Setup();

            var actual = sut.Solve(board, new List<IBoardRule>{
                new RowRule(),
                new ColumnRule(),
                new SquareRule()
            });

            actual.Print().Should().Be(solution.Print());
        }

        // https://www.youtube.com/watch?v=G_UYXzGuqvM&ab_channel=Computerphile
        [Fact]
        public void Solve3()
        {
            var board = new MatrixBoard(new int[9, 9] {
                { 5, 3, 0, 0, 7, 0, 0, 0, 0 },
                { 6, 0, 0, 1, 9, 5, 0, 0, 0 },
                { 0, 9, 8, 0, 0, 0, 0, 6, 0 },
                { 8, 0, 0, 0, 6, 0, 0, 0, 3 },
                { 4, 0, 0, 8, 0, 3, 0, 0, 1 },
                { 7, 0, 0, 0, 2, 0, 0, 0, 6 },
                { 0, 6, 0, 0, 0, 0, 2, 8, 0 },
                { 0, 0, 0, 4, 1, 9, 0, 0, 5 },
                { 0, 0, 0, 0, 8, 0, 0, 7, 9 }
            });

            var solution = new MatrixBoard(new int[9, 9]
            {
                { 5, 3, 4, 6, 7, 8, 9, 1, 2 },
                { 6, 7, 2, 1, 9, 5, 3, 4, 8 },
                { 1, 9, 8, 3, 4, 2, 5, 6, 7 },
                { 8, 5, 9, 7, 6, 1, 4, 2, 3 },
                { 4, 2, 6, 8, 5, 3, 7, 9, 1 },
                { 7, 1, 3, 9, 2, 4, 8, 5, 6 },
                { 9, 6, 1, 5, 3, 7, 2, 8, 4 },
                { 2, 8, 7, 4, 1, 9, 6, 3, 5 },
                { 3, 4, 5, 2, 8, 6, 1, 7, 9 }
            });

            var sut = Setup();

            var actual = sut.Solve(board, new List<IBoardRule>{
                new RowRule(),
                new ColumnRule(),
                new SquareRule()
            });

            actual.Print().Should().Be(solution.Print());
        }
    }
}