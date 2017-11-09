using System;
using System.Collections.Generic;
using Maze.Core;
using Maze.Models;

namespace Maze.Executors.MazeDimensionPropertiesExtractorExecutor
{
    public class MazeDimensionPropertiesExtractorExecutor : ExecutorBase<string, MazeDimensionProperties>, IMazeDimensionPropertiesExtractorExecutor
    {
        protected override MazeDimensionProperties OnExecute(string mazeStr)
        {
            // Get maze lines (rows).
            var rows = mazeStr.Split(
                new[] { "\r\n", "\r", "\n", "." },
                StringSplitOptions.None
            );

            var columnsLength = 0;
            var rowLines = new List<string>();

            // Iterate over the lines (rows) and calculate columns length.
            for (var i = 0; i < rows.Length; i++)
            {
                var row = rows[i];

                if (columnsLength == 0)
                {
                    columnsLength = row.Length; // Set the length to be equal to the first row length. 
                }
                else if (columnsLength != row.Length)
                {
                    // Check if the column length is equal to the previous one. If it's not something is not correct in the format of the maze.
                    throw new Exception("Could not transform Maze into a 2D matrix: Not all rows contain the same number of items");
                }

                rowLines.Add(row); // Store the line (row).
            }

            return new MazeDimensionProperties()
            {
                Rows = rowLines,
                ColumnsLength = columnsLength
            };
        }
    }
}