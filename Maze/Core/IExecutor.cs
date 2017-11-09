namespace Maze.Core
{
    /// <summary>
    ///     Provides single execution of an operation.    
    /// </summary>
    /// <typeparam name="TIn">Input.</typeparam>
    /// <typeparam name="TOut">Output.</typeparam>
    public interface IExecutor<in TIn, out TOut>
    {
        TOut Execute(TIn tin);
    }
}