using System;

namespace Maze.Core
{
    public abstract class Runnable : IRunnable
    {
        public void Start()
        {
            try
            {
                OnStart();
            }
            catch
            {
                Stop();
                throw;
            }
        }

        public void Stop()
        {
            OnStop();
        }

        protected abstract void OnStop();

        protected abstract void OnStart();

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize((object)this);
        }

        protected virtual void Dispose(bool disposing)
        {
            Stop();
        }
    }
}
