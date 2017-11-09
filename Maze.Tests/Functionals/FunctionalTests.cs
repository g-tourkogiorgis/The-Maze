using System.IO;
using System.Reflection;
using Maze.Executors.MazeCoordinatorExecutor;
using NUnit.Framework;
using Unity;

namespace Maze.Tests.Functionals
{
    [TestFixture]
    public class FunctionalTests
    {
        // We could user SpecFlow here for more readability.

        [Test]
        public void Given_Known_Maze_When_Solving_Then_The_Correct_Path_Is_Returned()
        {
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Mazes/maze.txt");

            using (var startup = new Startup())
            {
                startup.Start();

                var mazeCoordinatorExecutor = Startup.Container.Resolve<IMazeCoordinatorExecutor>();

                var expectedResult = "Solution path is: (0:0), (1:0), (2:0), (3:0), (4:0), (4:1), (4:2), (3:2), (3:3), (2:3), (2:4), (3:4)";

                var result = mazeCoordinatorExecutor.Execute(path);

                Assert.That(result.ToString(), Is.EqualTo(expectedResult));
            }
        }

        [Test]
        public void Given_Known_Maze_When_Solving_And_No_Path_Exists_Then_The_Correct_Path_Is_Returned()
        {
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Mazes/maze-no-solution.txt");

            using (var startup = new Startup())
            {
                startup.Start();

                var mazeCoordinatorExecutor = Startup.Container.Resolve<IMazeCoordinatorExecutor>();

                var expectedResult = "That was rough! Maze cannot be solved!";

                var result = mazeCoordinatorExecutor.Execute(path);

                Assert.That(result.ToString(), Is.EqualTo(expectedResult));
            }
        }
    }
}