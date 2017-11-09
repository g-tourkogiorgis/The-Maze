using Maze.Bootstrapping;
using Maze.Executors.MazeCoordinatorExecutor;
using Maze.Executors.MazeDimensionPropertiesExtractorExecutor;
using Maze.Executors.MazePathfinderAlgorithmExecutor;
using Maze.Executors.MazeTransformerExecutor;
using NUnit.Framework;
using Unity;

namespace Maze.Tests.Bootstrapping
{
    [TestFixture]
    public class ExecutorsSubsystemTests
    {
        [Test]
        public void Given_ExecutorsSubsystem_When_Initializing_Then_Dependencies_Are_Registered()
        {
            using (var startup = new Startup())
            {
                startup.Start();

                var container = Startup.Container;

                var executorsSubsystem = new ExecutorsSubsystem(container);
                executorsSubsystem.Start();

                var mazeCoordinatorExecutor = container.Resolve<IMazeCoordinatorExecutor>();
                var mazeTransformerExecutor = container.Resolve<IMazeTransformerExecutor>();
                var mazePathfinderAlgorithmExecutor = container.Resolve<IMazePathfinderAlgorithmExecutor>();
                var mazeDimensionPropertiesExtractorExecutor = container.Resolve<IMazeDimensionPropertiesExtractorExecutor>();

                Assert.IsNotNull(mazeCoordinatorExecutor);
                Assert.IsNotNull(mazeTransformerExecutor);
                Assert.IsNotNull(mazePathfinderAlgorithmExecutor);
                Assert.IsNotNull(mazeDimensionPropertiesExtractorExecutor);
            }
        }
    }
}