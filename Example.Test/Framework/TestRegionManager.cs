using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using Microsoft.Practices.Unity;
using Prism.Regions;

namespace Example.Test.Framework
{
    internal class TestRegionManager : IRegionManager
    {
        private readonly IDictionary<string, object> _viewModels;
        private readonly IUnityContainer _container;

        public TestRegionManager( IDictionary<string, object> viewModels, IUnityContainer container )
        {
            _viewModels = viewModels;
            _container = container;
        }

        public IRegionManager CreateRegionManager()
        {
            throw new NotImplementedException();
        }

        public IRegionManager AddToRegion( string regionName, object view )
        {
            throw new NotImplementedException();
        }

        public IRegionManager RegisterViewWithRegion( string regionName, Type viewType )
        {
            throw new NotImplementedException();
        }

        public IRegionManager RegisterViewWithRegion( string regionName, Func<object> getContentDelegate )
        {
            throw new NotImplementedException();
        }

        public void RequestNavigate( string regionName, Uri source, Action<NavigationResult> navigationCallback )
        {
            throw new NotImplementedException();
        }

        public void RequestNavigate( string regionName, Uri source )
        {
            throw new NotImplementedException();
        }

        public void RequestNavigate( string regionName, string source, Action<NavigationResult> navigationCallback )
        {
            throw new NotImplementedException();
        }

        public void RequestNavigate( string regionName, string source )
        {
            var viewType = _container.Registrations.Single( x => x.Name == source ).MappedToType;
            var str1 = viewType.FullName.Replace( ".Views.", ".ViewModels." );
            var fullName = viewType.GetTypeInfo().Assembly.FullName;
            var str2 = str1.EndsWith( "View" ) ? "Model" : "ViewModel";
            var viewModelType = Type.GetType( string.Format( (IFormatProvider)CultureInfo.InvariantCulture, "{0}{1}, {2}", (object)str1, (object)str2, (object)fullName ) );

            var viewModel = _container.Resolve( viewModelType );
            _viewModels[ regionName ] = viewModel;
        }

        public void RequestNavigate( string regionName, Uri target, Action<NavigationResult> navigationCallback, NavigationParameters navigationParameters )
        {
            throw new NotImplementedException();
        }

        public void RequestNavigate( string regionName, string target, Action<NavigationResult> navigationCallback, NavigationParameters navigationParameters )
        {
            throw new NotImplementedException();
        }

        public void RequestNavigate( string regionName, Uri target, NavigationParameters navigationParameters )
        {
            throw new NotImplementedException();
        }

        public void RequestNavigate( string regionName, string target, NavigationParameters navigationParameters )
        {
            throw new NotImplementedException();
        }

        public IRegionCollection Regions { get; }
    }
}