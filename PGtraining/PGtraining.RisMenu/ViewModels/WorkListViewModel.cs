using PGtraining.Lib.Log;
using PGtraining.Lib.Setting;
using PGtraining.RisMenu.Model;
using Prism.Mvvm;
using Prism.Regions;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;

namespace PGtraining.RisMenu.ViewModels
{
    public class WorkListViewModel : BindableBase, INavigationAware
    {
        public ReactiveCommand ReloadCommand { get; }
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

            this.ReloadCommand = new ReactiveCommand();
            this.ImportCommand = new ReactiveCommand();
            this.LogoutCommand = new ReactiveCommand();
            this.BackCommand = new ReactiveCommand();

            this.ReloadCommand.Subscribe(()=> this.Reload()).AddTo(this.Disposables);
            this.ImportCommand.Subscribe( ()=> this.Import()).AddTo(this.Disposables);
            this.LogoutCommand.Subscribe(() => this.ToLogin()).AddTo(this.Disposables);
            this.BackCommand.Subscribe(() => this.ToMenu()).AddTo(this.Disposables); ;
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
            var model = new MenuModel(this.Setting);
            var param = new Prism.Regions.NavigationParameters();
            param.Add("Model", model);
            this.RegionManager.RequestNavigate("ContentRegion", this.ViewManager.Menu,param);
        }

        private void ToLogin()
        {
            var model = new LoginModel(this.Setting);
            var param = new Prism.Regions.NavigationParameters();
            param.Add("Model", model);
            this.RegionManager.RequestNavigate("ContentRegion", this.ViewManager.Login, param);
        }

        /// <summary>
        /// DB再読み込み
        /// </summary>
        private void Reload()
        {
            this.Model.Reload();
        }

        /// <summary>
        /// フォルダ内のファイル読込
        /// </summary>
        private void Import()
        {
            this.Model.Import();
            this.Model.Reload();
        }
    }
}