﻿using PGtraining.Lib;
using PGtraining.RisMenu;
using PGtraining.Views;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;

namespace PGtraining
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<Lib.Setting.Setting>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<RisMenuModule>(InitializationMode.WhenAvailable);
            moduleCatalog.AddModule<LibModule>(InitializationMode.WhenAvailable);
        }
    }
}