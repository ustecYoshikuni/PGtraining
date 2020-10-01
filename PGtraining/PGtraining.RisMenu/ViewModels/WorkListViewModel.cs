using PGtraining.Lib.Log;
using PGtraining.Lib.Setting;
using PGtraining.RisMenu.Model;
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

        private System.Reactive.Disposables.CompositeDisposable Disposables = new System.Reactive.Disposables.CompositeDisposable();

        public ReadOnlyReactiveCollection<OrderModel> WorkList { get; set; }

        private Log Log = new Log();

        private WorkListModel Model = null;
        private Setting Setting = null;

        public WorkListViewModel(IRegionManager regionManager, ViewManager viewManager, Setting setting)
        {
            this.RegionManager = regionManager;
            this.ViewManager = viewManager;
            this.Setting = setting;

            this.ImportCommand = new ReactiveCommand();
            this.LogoutCommand = new ReactiveCommand();
            this.BackCommand = new ReactiveCommand();

            this.LogoutCommand.Subscribe(() => this.ToMenu());
            this.BackCommand.Subscribe(() => this.RegionNavigationService.Journal.GoBack());
            this.ImportCommand.Subscribe(() => this.Import());
        }

        #region 画面遷移

        public bool IsNavigationTarget(NavigationContext navigationContext) => true;

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            this.RegionNavigationService = navigationContext.NavigationService;
            this.Model = navigationContext.Parameters["Model"] as WorkListModel;
            this.Setting = this.Model.Setting;

            this.WorkList = this.Model.WorkList.ToReadOnlyReactiveCollection();

            this.RaisePropertyChanged(null);
        }

        #endregion 画面遷移

        private void ToMenu()
        {
            this.RegionManager.RequestNavigate("ContentRegion", this.ViewManager.Menu);
        }

        /// <summary>
        /// フォルダ内のファイル読込
        /// </summary>
        private void Import()
        {
            this.Model.Import();
        }
    }
}