using Prism.Ioc;
using Prism.Modularity;

namespace PGtraining.Lib
{
    public class LibModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<Setting.ViewManager>();
        }
    }
}