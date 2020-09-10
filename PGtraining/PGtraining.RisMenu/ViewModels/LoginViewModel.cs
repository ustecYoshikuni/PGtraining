using PGtraining.Lib.Setting;
using Prism.Mvvm;
using Prism.Regions;
using Reactive.Bindings;

namespace PGtraining.RisMenu.ViewModels
{
    public class LoginViewModel : BindableBase, INavigationAware
    {
        public ReactiveCommand LoginCommand { get; }

        private IRegionManager RegionManager { get; set; }
        private IRegionNavigationService RegionNavigationService { get; set; }

        private ViewManager ViewManager;

        public LoginViewModel()
        {
        }

        public LoginViewModel(IRegionManager regionManager, ViewManager viewManager)
        {
            this.RegionManager = regionManager;
            this.ViewManager = viewManager;

            this.LoginCommand = new ReactiveCommand();

            this.LoginCommand.Subscribe(() => ToMenu());
        }

        #region '画面遷移'

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            this.RegionNavigationService = navigationContext.NavigationService;
        }

        public bool IsNavigationTarget(NavigationContext navigationContext) => true;

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        #endregion '画面遷移'

        private void ToMenu()
        {
            this.RegionManager.RequestNavigate("ContentRegion", this.ViewManager.Menu);
        }
    }
}