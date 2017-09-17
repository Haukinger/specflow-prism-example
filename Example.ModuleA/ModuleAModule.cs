using Prism.Modularity;
using Prism.Regions;
using System;
using System.Windows;
using Example.ModuleA.ViewModels;
using Example.ModuleA.Views;
using Example.Shared.Events;
using JetBrains.Annotations;
using Microsoft.Practices.Unity;
using Prism.Events;
using Prism.Unity;

namespace Example.ModuleA
{
    [UsedImplicitly]
    public class ModuleAModule : IModule
    {
        private readonly IRegionManager _regionManager;
        private readonly IEventAggregator _eventAggregator;
        private readonly IUnityContainer _container;

        public ModuleAModule( IRegionManager regionManager, IEventAggregator eventAggregator, IUnityContainer container )
        {
            _regionManager = regionManager;
            _eventAggregator = eventAggregator;
            _container = container;
        }

        public void Initialize()
        {
            //Application.Current.Resources.MergedDictionaries.Add( new ResourceDictionary { Source = new Uri( "pack://application:,,,/Example.ModuleA;component/Views/LoadRotorsView.xaml", UriKind.Absolute ) } );
            //_container.RegisterTypeForNavigation<LoadRotorsViewModel>( nameof(LoadRotorsViewModel) );
            //_eventAggregator.GetEvent<ModuleInitializationCompleteEvent>().Subscribe( () => _regionManager.RequestNavigate( "ContentRegion", nameof(LoadRotorsViewModel) ), ThreadOption.UIThread, true );
            _container.RegisterTypeForNavigation<InventoryView>( nameof(InventoryView) );
            _eventAggregator.GetEvent<ModuleInitializationCompleteEvent>().Subscribe( () => _regionManager.RequestNavigate( "ContentRegion", nameof(InventoryView) ), true );
        }
    }
}