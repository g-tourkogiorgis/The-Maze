using System;
using Maze.Core;
using Maze.Executors.MazeDimensionPropertiesExtractorExecutor;
using Maze.Models;

namespace Maze.Executors.MazeTransformerExecutor
{
    public class MazeTransformerExecutor : ExecutorBase<string, MazeModel>, IMazeTransformerExecutor
    {
        private readonly IMazeDimensionPropertiesExtractorExecutor _mazeDimensionPropertiesExtractor;

        public MazeTransformerExecutor(IMazeDimensionPropertiesExtractorExecutor mazeDimensionPropertiesExtractor)
        {
            if (mazeDimensionPropertiesExtractor == null) throw new ArgumentNullException(nameof(mazeDimensionPropertiesExtractor));

            _mazeDimensionPropertiesExtractor = mazeDimensionPropertiesExtractor;
        }

        protected override MazeModel OnExecute(string mazeStr)
        {
            // Get maze dimension properties.
            var dimensions = _mazeDimensionPropertiesExtractor.Execute(mazeStr);

            var maze = new MazeModel() {MazeDimensionProperties = dimensions};

            // Initialize a 2D matrix to represent the maze.
            var matrix = new Point[dimensions.RowsLength, dimensions.ColumnsLength];

            // Populate matrix values.
            for (int x = 0; x < dimensions.RowsLength; x++)
            {
                var row = maze.MazeDimensionProperties.Rows[x];

                for (var y = 0; y < maze.MazeDimensionProperties.ColumnsLength; y++)
                {
                    var valueToLower = char.ToLower(row[y]);

                    var cell = new Point()
                    {
                        X = x,
                        Y = y
                    };

                    switch (valueToLower)
                    {
                        case Constants.WALL_AS_CHAR:
                            cell.Value = Value.Wall;
                            break;
                        case Constants.STARTING_POINT_CHAR:
                            cell.Value = Value.Start;
                            maze.StartPoint = cell;
                            break;
                        case Constants.FINISH_POINT_CHAR:
                            cell.Value = Value.Finish;
                            maze.FinishPoint = cell;
                            break;
                        default:
                            cell.Value = Value.Free;
                            break;
                    }

                    matrix[x, y] = cell;
                }
            }

            maze.Matrix = matrix;

            return maze;
        }
    }
}