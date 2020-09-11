using PGtraining.Lib.Import;
using PGtraining.Lib.Setting;
using Prism.Mvvm;
using Prism.Regions;
using Reactive.Bindings;

namespace PGtraining.RisMenu.ViewModels
{
    public class WorkListViewModel : BindableBase, INavigationAware
    {
        public ReactiveCommand ImportCommand { get; }
        public ReactiveCommand LogoutCommand { get; }
        public ReactiveCommand BackCommand { get; }

        private IRegionManager RegionManager { get; set; }
        private IRegionNavigationService RegionNavigationService { get; set; }

        private ViewManager ViewManager;

        public WorkListViewModel(IRegionManager regionManager, ViewManager viewManager)
        {
            this.RegionManager = regionManager;
            this.ViewManager = viewManager;

            this.ImportCommand = new ReactiveCommand();
            this.LogoutCommand = new ReactiveCommand();
            this.BackCommand = new ReactiveCommand();

            this.LogoutCommand.Subscribe(() => this.ToMenu());
            this.BackCommand.Subscribe(() => this.RegionNavigationService.Journal.GoBack());
            this.ImportCommand.Subscribe(() => this.Import());
        }

        #region 画面遷移

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            this.RegionNavigationService = navigationContext.NavigationService;
        }

        public bool IsNavigationTarget(NavigationContext navigationContext) => true;

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        #endregion 画面遷移

        private void ToMenu()
        {
            this.RegionManager.RequestNavigate("ContentRegion", this.ViewManager.Menu);
        }

        private void Import()
        {
            var csvImport = new CsvImport();
            csvImport.Import(@"C:\Users\Yoshikuni\source\repos\PGtraining\PGtraining\sample\2020060112000000.csv");
        }
    }
}