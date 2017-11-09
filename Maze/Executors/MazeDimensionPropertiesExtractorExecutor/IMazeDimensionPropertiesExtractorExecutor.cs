using Maze.Core;
using Maze.Models;

namespace Maze.Executors.MazeDimensionPropertiesExtractorExecutor
{
    /// <summary>
    ///     Extracts all needed maze matrix properties like rows, columns, lines, etc.
    /// </summary>
    public interface IMazeDimensionPropertiesExtractorExecutor : IExecutor<string, MazeDimensionProperties>
    {
        
    }
}