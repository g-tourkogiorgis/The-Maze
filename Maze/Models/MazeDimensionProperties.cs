using System.Collections.Generic;

namespace Maze.Models
{
    /// <summary>
    ///     Contains Maze information about its dimensions.
    /// </summary>
    public class MazeDimensionProperties
    {
        public MazeDimensionProperties()
        {
            Rows = new List<string>();
        }

        public List<string> Rows { get; set; }
        public int RowsLength => Rows.Count;
        public int ColumnsLength { get; set; }
    }
}