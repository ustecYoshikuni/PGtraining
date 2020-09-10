using PGtraining.Lib.Setting;
using Prism.Mvvm;
using Prism.Regions;
using Reactive.Bindings;

namespace PGtraining.RisMenu.ViewModels
{
    public class WorkListViewModel : BindableBase, INavigationAware
    {
        public ReactiveCommand LogoutCommand { get; }
        public ReactiveCommand BackCommand { get; }

        private IRegionManager RegionManager { get; set; }
        private IRegionNavigationService RegionNavigationService { get; set; }

        private ViewManager ViewManager;

        public WorkListViewModel(IRegionManager regionManager, ViewManager viewManager)
        {
            this.RegionManager = regionManager;
            this.ViewManager = viewManager;

            this.LogoutCommand = new ReactiveCommand();
            this.BackCommand = new ReactiveCommand();

            this.LogoutCommand.Subscribe(() => this.ToMenu());
            this.BackCommand.Subscribe(() => this.RegionNavigationService.Journal.GoBack());
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            this.RegionNavigationService = navigationContext.NavigationService;
        }

        public bool IsNavigationTarget(NavigationContext navigationContext) => true;

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        private void ToMenu()
        {
            this.RegionManager.RequestNavigate("ContentRegion", this.ViewManager.Menu);
        }
    }
}