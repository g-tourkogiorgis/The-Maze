using Maze.Bootstrapping;
using Maze.Services.MazeProvider;
using NUnit.Framework;
using Unity;

namespace Maze.Tests.Bootstrapping
{
    [TestFixture]
    public class ServicesSubsystemTests
    {
        [Test]
        public void Given_ServicesSubsystem_When_Initializing_Then_Dependencies_Are_Registered()
        {
            using (var startup = new Startup())
            {
                startup.Start();

                var container = Startup.Container;

                var executorsSubsystem = new ServicesSubsystem(container);
                executorsSubsystem.Start();

                var mazeSource = container.Resolve<IMazeSource>();

                Assert.IsNotNull(mazeSource);
            }
        }
    }
}