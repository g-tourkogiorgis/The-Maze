using System;
using Maze.Core;
using Maze.Executors.MazePathfinderAlgorithmExecutor;
using Maze.Executors.MazeTransformerExecutor;
using Maze.Models;
using Maze.Services.MazeProvider;
using Maze.Validators;

namespace Maze.Executors.MazeCoordinatorExecutor
{
    public class MazeCoordinatorExecutor : ExecutorBase<string, Solution>, IMazeCoordinatorExecutor
    {
        private readonly IMazeSource _mazeSource;
        private readonly IMazeValidator _mazeValidator;
        private readonly IMazeTransformerExecutor _mazeTransformer;
        private readonly IMazePathfinderAlgorithmExecutor _mazePathfinderAlgorithmExecutor;

        public MazeCoordinatorExecutor(
            IMazeSource mazeSource,
            IMazeValidator mazeValidator,
            IMazeTransformerExecutor mazeTransformer,
            IMazePathfinderAlgorithmExecutor mazePathfinderAlgorithmExecutor)
        {
            if (mazeSource == null) throw new ArgumentNullException(nameof(mazeSource));
            if (mazeValidator == null) throw new ArgumentNullException(nameof(mazeValidator));
            if (mazeTransformer == null) throw new ArgumentNullException(nameof(mazeTransformer));
            if (mazePathfinderAlgorithmExecutor == null) throw new ArgumentNullException(nameof(mazePathfinderAlgorithmExecutor));

            _mazeSource = mazeSource;
            _mazeValidator = mazeValidator;
            _mazeTransformer = mazeTransformer;
            _mazePathfinderAlgorithmExecutor = mazePathfinderAlgorithmExecutor;
        }

        protected override Solution OnExecute(string source)
        {
            var rawMaze = _mazeSource.GetMaze(source);

            _mazeValidator.Validate(rawMaze);

            var maze = _mazeTransformer.Execute(rawMaze);

            return _mazePathfinderAlgorithmExecutor.Execute(maze);
        }
    }
}