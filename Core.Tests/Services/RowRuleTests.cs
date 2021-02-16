using Core.Models;
using Core.Services;
using FluentAssertions;
using Xunit;

namespace Core.Tests.Services
{
    public class RowRuleTests
    {
        [Fact]
        public void WhenValueExists_ReturnFalse()
        {
            var value = 8;
            var board = new MatrixBoard(new int[9, 9] {
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, value, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 }
            });
            var sut = new RowRule();

            var actual = sut.Test(board, new Point(6, 4), value);

            actual.Should().BeFalse();
        }

        [Fact]
        public void WhenValueDoesNotExist_ReturnTrue()
        {
            var value = 8;
            var board = new MatrixBoard(new int[9, 9] {
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 }
            });
            var sut = new RowRule();

            var actual = sut.Test(board, new Point(6, 4), value);

            actual.Should().BeTrue();
        }
    }

}