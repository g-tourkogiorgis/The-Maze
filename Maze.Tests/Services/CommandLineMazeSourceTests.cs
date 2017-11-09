using Maze.Services.MazeProvider;
using NUnit.Framework;

namespace Maze.Tests.Services
{
    [TestFixture]
    public class CommandLineMazeSourceTests
    {
        [Test]
        public void Given_CommandLineMazeSource_When_Getting_Maze_Then_The_Expected_Maze_Is_Returned()
        {
            var input = "maze";

            var source = new CommandLineMazeSource();

            var maze = source.GetMaze(input);

            Assert.That(maze, Is.EqualTo(input));
        }
    }
}