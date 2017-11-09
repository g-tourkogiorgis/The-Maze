using Maze.Core;

namespace Maze.Models
{
    /// <summary>
    ///     Represents a point of a 2D matrix.
    /// </summary>
    public struct Point
    {
        public int X { get; set; }

        public int Y { get; set; }

        public Value Value { get; set; }
    }
}