namespace Maze.Validators
{
    /// <summary>
    ///     Validates the provided maze.
    /// </summary>
    public interface IMazeValidator
    {
        void Validate(string mazeStr);
    }
}