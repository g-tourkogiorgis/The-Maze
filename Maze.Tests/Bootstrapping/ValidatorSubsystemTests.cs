using Maze.Bootstrapping;
using Maze.Validators;
using NUnit.Framework;
using Unity;

namespace Maze.Tests.Bootstrapping
{
    [TestFixture]
    public class ValidatorSubsystemTests
    {
        [Test]
        public void Given_ValidatorSubsystem_When_Initializing_Then_Dependencies_Are_Registered()
        {
            using (var startup = new Startup())
            {
                startup.Start();

                var container = Startup.Container;

                var executorsSubsystem = new ValidatorSubsystem(container);
                executorsSubsystem.Start();

                var mazeValidator = container.Resolve<IMazeValidator>();

                Assert.IsNotNull(mazeValidator);
            }
        }
    }
}