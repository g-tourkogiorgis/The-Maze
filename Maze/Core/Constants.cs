namespace Maze.Core
{
    /// <summary>
    ///     Contains all program's constant values (and the amazing logo :)).
    /// </summary>
    public class Constants
    {
        public const char WALL_AS_CHAR = 'x';
        public const string QUIT_SYMBOL = "q";
        public const char FREE_CELL_AS_CHAR = '_';
        public const char FINISH_POINT_CHAR = 'g';
        public const char STARTING_POINT_CHAR = 's';

        public const string Logo = @"
 _______ _            __  __                
|__   __| |          |  \/  |               
   | |  | |__   ___  | \  / | __ _ _______  
   | |  | '_ \ / _ \ | |\/| |/ _` |_  / _ \ 
   | |  | | | |  __/ | |  | | (_| |/ /  __/ 
   |_|  |_| |_|\___| |_|  |_|\__,_/___\___|                                              
";
    }
}