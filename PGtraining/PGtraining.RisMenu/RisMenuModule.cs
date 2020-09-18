using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace PGtraining.RisMenu
{
    public class RisMenuModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            // DIコンテナのPrismのフレームワークの画面管理
            var regionManeger = containerProvider.Resolve<IRegionManager>();
            regionManeger.RegisterViewWithRegion("ContentRegion", typeof(Views.Login));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // DIコンテナにインスタンスを登録
            containerRegistry.RegisterForNavigation<Views.Login>();
            containerRegistry.RegisterForNavigation<Views.Menu>();
            containerRegistry.RegisterForNavigation<Views.WorkList>();
            containerRegistry.RegisterForNavigation<Views.Setting>();
        }
    }
}