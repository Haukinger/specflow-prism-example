using System.Collections.Generic;
using Example.ModuleA;
using Example.Shared.Events;
using Example.Test.Steps;
using Microsoft.Practices.Unity;
using Prism.Events;
using Prism.Modularity;
using Prism.Regions;
using Prism.Unity;

namespace Example.Test.Framework
{
    internal class TestApplication : UnityBootstrapper
    {
        private readonly Dictionary<string, object> _viewModels = new Dictionary<string, object>();

        public IReadOnlyDictionary<string, object> ViewModels => _viewModels;

        protected override void ConfigureModuleCatalog()
        {
            ((ModuleCatalog)ModuleCatalog).AddModule( typeof(ModuleAModule) );
        }

        protected override void ConfigureContainer()
        {
            Container.RegisterInstance<IRegionManager>( new TestRegionManager( _viewModels, Container ), new ContainerControlledLifetimeManager() );
            base.ConfigureContainer();
        }

        protected override void InitializeModules()
        {
            base.InitializeModules();
            Container.Resolve<IEventAggregator>().GetEvent<ModuleInitializationCompleteEvent>().Publish();
        }
    }
}