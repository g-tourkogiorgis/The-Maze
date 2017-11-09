using System;
using System.Linq;
using System.Text.RegularExpressions;
using Maze.Core;

namespace Maze.Validators
{
    public class MazeValidator : IMazeValidator
    {
        private const string PATERN = @"^[_GSX.\n\r]+$";

        public void Validate(string mazeStr)
        {
            if (string.IsNullOrWhiteSpace(mazeStr))
                throw new ArgumentException("The string representation of the maze was empty.");

            var match = Regex.Match(mazeStr, PATERN, RegexOptions.IgnoreCase);

            if (!match.Success)
                throw new ArgumentException("The string representation of the maze contains invalid characters. Maze must only contain '_', 'X', 'S', 'G', '\\n', '\\r'");

            if (!mazeStr.ToLower().Contains(Constants.STARTING_POINT_CHAR) ||
                !mazeStr.ToLower().Contains(Constants.FINISH_POINT_CHAR))
                    throw new ArgumentException("The Maze must contain a starting point ('S') and a finish point ('G')");
        }
    }
}