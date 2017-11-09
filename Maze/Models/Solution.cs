using System;
using System.Collections.Generic;

namespace Maze.Models
{
    /// <summary>
    ///     The Maze solution model.
    /// </summary>
    public class Solution
    {
        public Solution()
        {
            CorrectPoints = new Stack<Point>();
        }

        public Stack<Point> CorrectPoints { get; set; }

        public override string ToString()
        {
            // Override default implementation to return a formatted string containing the solution path.

            if (CorrectPoints.Count == 0)
                return "That was rough! Maze cannot be solved!";

            var pathFormatted = string.Empty;

            foreach (var point in CorrectPoints)
            {
                pathFormatted += $"({point.X}:{point.Y}), ";
            }

            return $"Solution path is: {pathFormatted.Substring(0, pathFormatted.Length - 2)}";
        }
    }
}