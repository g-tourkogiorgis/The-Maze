namespace Maze.Services.MazeProvider
{
    /// <summary>
    ///     Provides different Maze sources.
    /// </summary>
    public interface IMazeSource
    {
        string SourcePromptMessage { get; }

        string GetMaze(string source);
    }
}