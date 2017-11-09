namespace Maze.Core
{
    /// <summary>
    ///     Provides single execution of an operation.    
    /// </summary>
    /// <typeparam name="TIn">Input.</typeparam>
    /// <typeparam name="TOut">Output.</typeparam>
    public abstract class ExecutorBase<TIn, TOut>
    {
        public TOut Execute(TIn tin)
        {
            return OnExecute(tin);
        }

        protected abstract TOut OnExecute(TIn tin);
    }
}