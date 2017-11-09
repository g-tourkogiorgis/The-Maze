using System.Collections.Generic;
using System.Linq;
using Maze.Core;
using Maze.Models;

namespace Maze.Executors.MazePathfinderAlgorithmExecutor
{
    public class RecursiveAlgorithmExecutor : ExecutorBase<MazeModel, Solution>, IMazePathfinderAlgorithmExecutor
    {
        private MazeModel _maze; // The maze to solve.
        private bool[,] _visited; // A matrix containing boolean values indiacating if a point is visited.
        private bool[,] _correctPath; // A matrix containing boolean values indiacating the correct path as true values.
        private Stack<Point> _solutionPath; // A stack to hold the solution path.

        protected override Solution OnExecute(MazeModel maze)
        {
            _maze = maze;
            _solutionPath = new Stack<Point>();

            _visited = new bool[_maze.MazeDimensionProperties.RowsLength, _maze.MazeDimensionProperties.ColumnsLength];
            _correctPath = new bool[_maze.MazeDimensionProperties.RowsLength, _maze.MazeDimensionProperties.ColumnsLength];

            RecursiveSolve(_maze.StartPoint.X, _maze.StartPoint.Y);

            return new Solution() {CorrectPoints = _solutionPath};
        }

        private bool RecursiveSolve(int x, int y)
        {
            // Found the way to the finishing point.
            if (x == _maze.FinishPoint.X && y == _maze.FinishPoint.Y) {
                _solutionPath.Push(_maze.FinishPoint);
                return true;
            }

            // If you hit a wall or already visited this point.
            if (_maze.Matrix[x, y].Value == Value.Wall || _visited[x, y]) return false;
            
            _visited[x, y] = true;

            if (x != 0) // If not on left edge.
                if (RecursiveSolve(x - 1, y)) // Move West.
                { 
                    _solutionPath.Push(new Point()
                    {
                        X = x,
                        Y = y
                    });
                    _correctPath[x, y] = true;
                    return true;
                }
            if (x != _maze.MazeDimensionProperties.RowsLength - 1) // If not on right edge.
                if (RecursiveSolve(x + 1, y)) // Move East
                { 
                    _correctPath[x, y] = true;
                    _solutionPath.Push(new Point()
                    {
                        X = x,
                        Y = y
                    });
                    return true;
                }
            if (y != 0)  // If not on top edge
                if (RecursiveSolve(x, y - 1)) // Move South
                { 
                    _correctPath[x, y] = true;
                    _solutionPath.Push(new Point()
                    {
                        X = x,
                        Y = y
                    });
                    return true;
                }
            if (y != _maze.MazeDimensionProperties.ColumnsLength - 1) // If not on bottom edge
                if (RecursiveSolve(x, y + 1)) // Move North
                {
                    _correctPath[x, y] = true;
                    _solutionPath.Push(new Point()
                    {
                        X = x,
                        Y = y
                    });
                    return true;
                }

            if (_solutionPath.Any()) _solutionPath.Pop();
            _visited[x, y] = false;
            return false;
        }
    }
}
