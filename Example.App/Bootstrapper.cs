using Microsoft.Practices.Unity;
using Prism.Unity;
using Example.App.Views;
using System.Windows;
using Example.Shared.Events;
using Prism.Events;
using Prism.Modularity;

namespace Example.App
{
    internal class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new DirectoryModuleCatalog { ModulePath = "." };
        }

        protected override void InitializeModules()
        {
            new SplashScreen( "Resources/Splash.png" ).Show( true, true );
            base.InitializeModules();
            Application.Current.MainWindow.Show();
            Container.Resolve<IEventAggregator>().GetEvent<ModuleInitializationCompleteEvent>().Publish();
        }
    }
}