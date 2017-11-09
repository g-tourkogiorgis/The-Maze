using System.IO;

namespace Maze.Services.MazeProvider
{
    public class FileMazeSource : IMazeSource
    {
        public string SourcePromptMessage => "Please insert Maze absolute file path:";

        public string GetMaze(string source)
        {
            // In order for this class to be unit tested we could wrap the File.ReadAllText to a IFile interface.
            // Then we could mock the IFile.
            return File.ReadAllText(source); // For a more efficient approach we would use StreamReader.ReadToEnd.
        }
    }
}