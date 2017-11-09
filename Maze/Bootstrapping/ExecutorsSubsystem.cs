using System;
using Maze.Core;
using Maze.Executors.MazeCoordinatorExecutor;
using Maze.Executors.MazeDimensionPropertiesExtractorExecutor;
using Maze.Executors.MazePathfinderAlgorithmExecutor;
using Maze.Executors.MazeTransformerExecutor;
using Unity;

namespace Maze.Bootstrapping
{
    /// <summary>
    ///     Registers executors in the IoC container. Here you can register any maze-solving algorithm as long it implements the IMazePathfinderAlgorithmExecutor interface.
    /// </summary>
    public class ExecutorsSubsystem : Runnable
    {
        private readonly IUnityContainer _container;

        public ExecutorsSubsystem(IUnityContainer container)
        {
            if (container == null) throw new ArgumentNullException(nameof(container));

            _container = container;
        }

        protected override void OnStart()
        {
            _container.RegisterType<IMazeDimensionPropertiesExtractorExecutor, MazeDimensionPropertiesExtractorExecutor>();
            _container.RegisterType<IMazeTransformerExecutor, MazeTransformerExecutor>();
            _container.RegisterType<IMazePathfinderAlgorithmExecutor, RecursiveAlgorithmExecutor>();
            _container.RegisterType<IMazeCoordinatorExecutor, MazeCoordinatorExecutor>();
        }

        protected override void OnStop()
        {
            // Clean up resources if needed.
        }
    }
}