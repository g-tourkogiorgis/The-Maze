using System;
using Maze.Core;
using Maze.Services.MazeProvider;
using Unity;

namespace Maze.Bootstrapping
{
    /// <summary>
    ///     Registers all sub services in the IoC container.
    ///     Here you can register any maze source as long it implements the IMazeSource interface.
    /// </summary>
    public class ServicesSubsystem : Runnable
    {
        private readonly IUnityContainer _container;

        public ServicesSubsystem(IUnityContainer container)
        {
            if (container == null) throw new ArgumentNullException(nameof(container));

            _container = container;
        }

        protected override void OnStart()
        {
            _container.RegisterType<IMazeSource, FileMazeSource>();
        }

        protected override void OnStop()
        {
            // Clean up resources if needed.
        }
    }
}