namespace Maze
{
    class Program
    {
        private static Startup _startup;

        static void Main(string[] args)
        {
            using (_startup = new Startup())
            {
                _startup.Start();
                _startup.StartMaze();
            }
        }
    }
}
