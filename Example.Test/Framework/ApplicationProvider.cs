using BoDi;
using Example.Test.Steps;
using JetBrains.Annotations;
using TechTalk.SpecFlow;

namespace Example.Test.Framework
{
    [Binding]
    [UsedImplicitly]
    internal class ApplicationProvider
    {
        private readonly IObjectContainer _container;

        public ApplicationProvider( IObjectContainer container )
        {
            _container = container;
        }

        [BeforeScenario]
        public void Init()
        {
            var application = new TestApplication();
            _container.RegisterInstanceAs( application );
            application.Run();
        }
    }
}