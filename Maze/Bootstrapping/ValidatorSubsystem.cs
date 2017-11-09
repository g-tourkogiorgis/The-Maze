using System;
using Maze.Core;
using Maze.Validators;
using Unity;

namespace Maze.Bootstrapping
{
    /// <summary>
    ///     Registers all validators in the IoC container.
    /// </summary>
    public class ValidatorSubsystem : Runnable
    {
        private readonly IUnityContainer _container;

        public ValidatorSubsystem(IUnityContainer container)
        {
            if (container == null) throw new ArgumentNullException(nameof(container));

            _container = container;
        }

        protected override void OnStart()
        {
            _container.RegisterType<IMazeValidator, MazeValidator>();
        }

        protected override void OnStop()
        {
            // Clean up resources if needed.
        }
    }
}