using log4net;
using Maze.Bootstrapping;
using NUnit.Framework;
using Unity;

namespace Maze.Tests.Bootstrapping
{
    [TestFixture]
    public class LoggingSubsystemTests
    {
        [Test]
        public void Given_LoggingSubsystem_When_Initializing_Then_Dependencies_Are_Registered()
        {
            using (var startup = new Startup())
            {
                startup.Start();

                var container = Startup.Container;

                var executorsSubsystem = new LoggingSubsystem(container);
                executorsSubsystem.Start();

                var logger = container.Resolve<ILog>();

                Assert.IsNotNull(logger);
            }
        }
    }
}