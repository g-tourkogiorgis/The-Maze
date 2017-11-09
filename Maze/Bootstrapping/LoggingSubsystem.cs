using System;
using System.Configuration;
using System.IO;
using log4net;
using Maze.Core;
using Unity;

namespace Maze.Bootstrapping
{
    /// <summary>
    ///     <para/> Registers the logger in the IoC container. You can setup different logger configuration files depending the environment (Local, Staging, Production). 
    ///     <para/> Example configuration files are provided in the configs folder.
    /// </summary>
    public class LoggingSubsystem : Runnable
    {
        private readonly IUnityContainer _container;

        public LoggingSubsystem(IUnityContainer container)
        {
            if (container == null) throw new ArgumentNullException(nameof(container));

            _container = container;
        }

        protected override void OnStart()
        {
            var environment = ConfigurationManager.AppSettings["configuration-manager.environment"];
            var loggingFile = "configs/logging." + environment + ".config";
            var logger = LogManager.GetLogger(typeof(object));
            log4net.Config.XmlConfigurator.ConfigureAndWatch(new FileInfo(loggingFile));

            _container.RegisterInstance<ILog>(logger);
        }

        protected override void OnStop()
        {
            // Clean up resources if needed.
        }
    }
}