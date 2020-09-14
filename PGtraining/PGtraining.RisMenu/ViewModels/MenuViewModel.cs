using PGtraining.Lib.Setting;
using PGtraining.RisMenu.Model;
using Prism.Mvvm;
using Prism.Regions;
using Reactive.Bindings;

namespace PGtraining.RisMenu.ViewModels
{
    public class MenuViewModel : BindableBase, INavigationAware
    {
        public ReactiveCommand LogoutCommand { get; }
        public ReactiveCommand WorkListCommand { get; }
        private IRegionManager RegionManager { get; set; }
        private IRegionNavigationService RegionNavigationService { get; set; }

        private ViewManager ViewManager;

        public MenuViewModel(IRegionManager regionManager, ViewManager viewManager)
        {
            this.RegionManager = regionManager;
            this.ViewManager = viewManager;

            this.LogoutCommand = new ReactiveCommand();
            this.WorkListCommand = new ReactiveCommand();

            this.LogoutCommand.Subscribe(() => this.ToLogin());
            this.WorkListCommand.Subscribe(() => this.ToWorkList());
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            this.RegionNavigationService = navigationContext.NavigationService;
        }

        public bool IsNavigationTarget(NavigationContext navigationContext) => true;

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        private void ToLogin()
        {
            this.RegionManager.RequestNavigate("ContentRegion", this.ViewManager.Login);
        }

        private void ToWorkList()
        {
            var model = new WorkListModel();
            var param = new Prism.Regions.NavigationParameters();
            param.Add("Model", model);
            this.RegionManager.RequestNavigate("ContentRegion", ViewManager.WorkList, param);
        }
    }
}