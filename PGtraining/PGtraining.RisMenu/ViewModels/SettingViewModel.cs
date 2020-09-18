using PGtraining.Lib.Log;
using PGtraining.Lib.Setting;
using PGtraining.RisMenu.Model;
using Prism.Mvvm;
using Prism.Regions;
using Reactive.Bindings;

namespace PGtraining.RisMenu.ViewModels
{
    public class SettingViewModel : BindableBase, INavigationAware
    {
        public ReactiveCommand LogoutCommand { get; }
        public ReactiveCommand BackCommand { get; }

        private IRegionManager RegionManager { get; set; }
        private IRegionNavigationService RegionNavigationService { get; set; }

        private ViewManager ViewManager;

        private System.Reactive.Disposables.CompositeDisposable Disposables = new System.Reactive.Disposables.CompositeDisposable();

        private Log Log = new Log();

        private SettingModel Model = null;

        public SettingViewModel()
        {
        }

        public SettingViewModel(IRegionManager regionManager, ViewManager viewManager)
        {
            this.RegionManager = regionManager;
            this.ViewManager = viewManager;

            this.LogoutCommand = new ReactiveCommand();
            this.BackCommand = new ReactiveCommand();

            this.LogoutCommand.Subscribe(() => this.ToLogin());
            this.BackCommand.Subscribe(() => this.ToMenu());
        }

        public bool IsNavigationTarget(NavigationContext navigationContext) => true;

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            this.RegionNavigationService = navigationContext.NavigationService;
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
        }

        private void ToLogin()
        {
            this.RegionManager.RequestNavigate("ContentRegion", this.ViewManager.Login);
        }

        private void ToMenu()
        {
            this.RegionManager.RequestNavigate("ContentRegion", this.ViewManager.Menu);
        }
    }
}