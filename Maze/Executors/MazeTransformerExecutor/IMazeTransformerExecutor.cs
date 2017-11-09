using Maze.Core;

namespace Maze.Executors.MazeTransformerExecutor
{
    /// <summary>
    ///     Transforms raw string maze into a model.
    /// </summary>
    public interface IMazeTransformerExecutor : IExecutor<string, Models.MazeModel>
    {
        
    }
}