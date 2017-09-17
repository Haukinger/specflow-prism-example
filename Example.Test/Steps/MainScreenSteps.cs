using Example.ModuleA.ViewModels;
using Example.Test.Framework;
using JetBrains.Annotations;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Example.Test.Steps
{
    [Binding]
    [UsedImplicitly]
    internal class MainScreenSteps
    {
        private readonly TestApplication _app;

        public MainScreenSteps( TestApplication app )
        {
            _app = app;
        }

        [Then( @"the screen shows the main screen" )]
        public void ThenTheScreenShowsTheMainScreen()
        {
            Assert.That( _app.ViewModels[ "ContentRegion" ], Is.Not.Null.And.InstanceOf<InventoryViewModel>() );
        }
    }
}