namespace Maze.Models
{
    /// <summary>
    ///     Represents the Maze.
    /// </summary>
    public class MazeModel
    {
        public Point[,] Matrix { get; set; }
        public Point StartPoint { get; set; }
        public Point FinishPoint { get; set; }
        public MazeDimensionProperties MazeDimensionProperties { get; set; }
    }
}