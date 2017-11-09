using System.Collections.Generic;
using Maze.Models;
using NUnit.Framework;

namespace Maze.Tests.Models
{
    [TestFixture]
    public class SolutionTests
    {
        [Test]
        public void Given_Solution_Then_Path_Is_Instantiated()
        {
            var solution = new Solution();

            Assert.That(solution.CorrectPoints, Is.Not.Null);
        }

        [Test]
        public void Given_Solution_When_Getting_String_Representation_Then_The_Expected_String_Is_Returned()
        {
            var correctStack = new Stack<Point>();
            correctStack.Push(new Point()
            {
                X = 0,
                Y = 1
            });
            correctStack.Push(new Point()
            {
                X = 0,
                Y = 2
            });
            correctStack.Push(new Point()
            {
                X = 0,
                Y = 3
            });
            correctStack.Push(new Point()
            {
                X = 0,
                Y = 4
            });

            var solution = new Solution() {CorrectPoints = correctStack};

            Assert.That(solution.ToString(), Is.EqualTo("Solution path is: (0:4), (0:3), (0:2), (0:1)"));
        }
    }
}