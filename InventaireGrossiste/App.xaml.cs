using NLog;
using System;
using System.Windows;

namespace InventaireGrossiste
{
    public partial class App : Application
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public App()
        {
            // Initialisation de NLog
            LogManager.LoadConfiguration("config/NLog.config");
            Logger.Info("Application démarrée.");
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
        }
    }
}
