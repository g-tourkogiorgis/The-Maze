namespace Maze.Services.MazeProvider
{
    public class CommandLineMazeSource : IMazeSource
    {
        public string SourcePromptMessage => "Please insert Maze:";

        public string GetMaze(string source)
        {
            return source;
        }
    }
}