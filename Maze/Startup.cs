using System;
using log4net;
using Maze.Bootstrapping;
using Maze.Core;
using Maze.Executors.MazeCoordinatorExecutor;
using Maze.Services.MazeProvider;
using Unity;

namespace Maze
{
    public class Startup : Runnable
    {
        private static bool _isFirstRun;
        private readonly LoggingSubsystem _loggingSubsystem;
        private readonly ServicesSubsystem _servicesSubsystem;
        private readonly ValidatorSubsystem _validatorSubsystem;
        private readonly ExecutorsSubsystem _executorsSubsystem;

        public static UnityContainer Container;

        public Startup()
        {
            Container = new UnityContainer();

            _loggingSubsystem = new LoggingSubsystem(Container);
            _servicesSubsystem = new ServicesSubsystem(Container);
            _validatorSubsystem = new ValidatorSubsystem(Container);
            _executorsSubsystem = new ExecutorsSubsystem(Container);

            _isFirstRun = true;
        }

        protected override void OnStart()
        {
            _loggingSubsystem.Start();
            _servicesSubsystem.Start();
            _validatorSubsystem.Start();
            _executorsSubsystem.Start();
        }

        protected override void OnStop()
        {
            if (_executorsSubsystem != null) _executorsSubsystem.Stop();
            if (_validatorSubsystem != null) _validatorSubsystem.Stop();
            if (_servicesSubsystem != null) _servicesSubsystem.Stop();
            if (_loggingSubsystem != null) _loggingSubsystem.Stop();
        }

        public void StartMaze()
        {
            var logger = Container.Resolve<ILog>();
            var mazeSource = Container.Resolve<IMazeSource>();
            var mazeCoordinatorExecutor = Container.Resolve<IMazeCoordinatorExecutor>();

            try
            {
                if (_isFirstRun)
                {
                    Console.WriteLine(Constants.Logo);
                    _isFirstRun = false;
                }

                Console.WriteLine(mazeSource.SourcePromptMessage);
                var input = Console.ReadLine();

                var result = mazeCoordinatorExecutor.Execute(input);
                Console.WriteLine(result);

                Console.WriteLine("Press any key to restart ('q' for exit):");
                input = Console.ReadLine();

                if (input != Constants.QUIT_SYMBOL) StartMaze();
            }
            catch (Exception e)
            {
                logger.Error($"Oops something went wrong: {e.GetBaseException().Message}");
                Stop();

                Console.WriteLine("Restarting...");
                Start();
                StartMaze();
            }
        }
    }
}