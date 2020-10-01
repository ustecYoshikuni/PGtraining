using PGtraining.Lib.Setting;
using PGtraining.RisMenu.Model;
using Prism.Mvvm;
using Prism.Regions;
using Reactive.Bindings;

namespace PGtraining.RisMenu.ViewModels
{
    public class MenuViewModel : BindableBase, INavigationAware
    {
        public ReactiveCommand WorkListCommand { get; }
        public ReactiveCommand SettingCommand { get; }
        public ReactiveCommand LogoutCommand { get; }
        private IRegionManager RegionManager { get; set; }
        private IRegionNavigationService RegionNavigationService { get; set; }

        private ViewManager ViewManager = null;
        private Setting Setting = null;
        private MenuModel Model = null;

        public MenuViewModel(IRegionManager regionManager, ViewManager viewManager, Setting setting)
        {
            this.RegionManager = regionManager;
            this.ViewManager = viewManager;
            this.Setting = setting;

            this.WorkListCommand = new ReactiveCommand();
            this.SettingCommand = new ReactiveCommand();
            this.LogoutCommand = new ReactiveCommand();

            this.WorkListCommand.Subscribe(() => this.ToWorkList());
            this.SettingCommand.Subscribe(() => this.ToSetting());
            this.LogoutCommand.Subscribe(() => this.ToLogin());
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            this.RegionNavigationService = navigationContext.NavigationService;
            this.Model = navigationContext.Parameters["Model"] as MenuModel;
            this.Setting = this.Model.Setting;
        }

        public bool IsNavigationTarget(NavigationContext navigationContext) => true;

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        private void ToSetting()
        {
            var model = new SettingModel(this.Setting);
            var param = new Prism.Regions.NavigationParameters();
            param.Add("Model", model);
            this.RegionManager.RequestNavigate("ContentRegion", this.ViewManager.Setting, param);
        }

        private void ToLogin()
        {
            var model = new LoginModel(this.Setting);
            var param = new Prism.Regions.NavigationParameters();
            param.Add("Model", model);
            this.RegionManager.RequestNavigate("ContentRegion", this.ViewManager.Login, param);
        }

        private void ToWorkList()
        {
            var model = new WorkListModel(this.Setting);
            var param = new Prism.Regions.NavigationParameters();
            param.Add("Model", model);
            this.RegionManager.RequestNavigate("ContentRegion", this.ViewManager.WorkList, param);
        }
    }
}