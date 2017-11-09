using System;

namespace Maze.Core
{
    /// <summary>
    ///     Provides a mechanism for starting and stopping an action.
    /// </summary>
    public interface IRunnable : IDisposable
    {
        void Start();
        void Stop();
    }
}