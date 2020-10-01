using PGtraining.Lib.Log;
using PGtraining.Lib.Setting;
using PGtraining.RisMenu.Model;
using Prism.Mvvm;
using Prism.Regions;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;

namespace PGtraining.RisMenu.ViewModels
{
    public class SettingViewModel : BindableBase, INavigationAware
    {
        public ReactiveCommand ReturnCommand { get; set; }
        public ReactiveCommand SaveCommand { get; set; }
        public ReactiveCommand LogoutCommand { get; }
        public ReactiveCommand BackCommand { get; }

        public ReactiveProperty<bool> CanReturn { get; set; }
        public ReactiveProperty<bool> CanSave { get; set; }

        #region 'SettingModel同期用'

        /// <summary>
        /// 監視対象フォルダのパス
        /// </summary>
        public ReactiveProperty<string> ImportFolderPath { get; set; }

        /// <summary>
        /// ファイル名のパターン
        /// </summary>
        public ReactiveProperty<string> FileNamePattern { get; set; }

        /// <summary>
        /// 処理間隔期間
        /// </summary>
        public ReactiveProperty<int> IntervalSec { get; set; }

        /// <summary>
        /// 再処理間隔
        /// </summary>
        public ReactiveProperty<int> RetryIntervalSec { get; set; }

        /// <summary>
        /// 再処理回数
        /// </summary>
        public ReactiveProperty<int> RetryCount { get; set; }

        /// <summary>
        /// ログ出力フォルダのパス
        /// </summary>
        public ReactiveProperty<string> LogFolderPath { get; set; }

        /// <summary>
        /// 成功フォルダのパス
        /// </summary>
        public ReactiveProperty<string> SuccessFolderPath { get; set; }

        /// <summary>
        /// エラーフォルダのパス
        /// </summary>
        public ReactiveProperty<string> ErrorFolderPath { get; set; }

        public ReactiveProperty<Setting> Setting { get; set; }

        #endregion 'SettingModel同期用'

        private IRegionManager RegionManager { get; set; }
        private IRegionNavigationService RegionNavigationService { get; set; }

        private ViewManager ViewManager;

        private System.Reactive.Disposables.CompositeDisposable Disposables = new System.Reactive.Disposables.CompositeDisposable();

        private Log Log = new Log();

        private SettingModel Model = null;
        //private Setting Setting = null;

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
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            this.RegionNavigationService = navigationContext.NavigationService;
            this.Model = navigationContext.Parameters["Model"] as SettingModel;
            this.Setting = this.Model.Setting;

            this.ErrorFolderPath = this.Model.ErrorFolderPath
                .ToReactivePropertyAsSynchronized(x => x.Value)
                .AddTo(this.Disposables);

            this.FileNamePattern = this.Model.FileNamePattern
                .ToReactivePropertyAsSynchronized(x => x.Value)
                .AddTo(this.Disposables);

            this.ImportFolderPath = this.Model.ImportFolderPath
                .ToReactivePropertyAsSynchronized(x => x.Value)
                .AddTo(this.Disposables);

            this.IntervalSec = this.Model.IntervalSec
                .ToReactivePropertyAsSynchronized(x => x.Value)
                .AddTo(this.Disposables);

            this.LogFolderPath = this.Model.LogFolderPath
                .ToReactivePropertyAsSynchronized(x => x.Value)
                .AddTo(this.Disposables);

            this.RetryCount = this.Model.RetryCount
                .ToReactivePropertyAsSynchronized(x => x.Value)
                .AddTo(this.Disposables);

            this.RetryIntervalSec = this.Model.RetryIntervalSec
                .ToReactivePropertyAsSynchronized(x => x.Value)
                .AddTo(this.Disposables);

            this.SuccessFolderPath = this.Model.SuccessFolderPath
                .ToReactivePropertyAsSynchronized(x => x.Value)
                .AddTo(this.Disposables);

            this.RetryIntervalSec = this.Model.RetryIntervalSec
                .ToReactivePropertyAsSynchronized(x => x.Value)
                .AddTo(this.Disposables);

            this.SuccessFolderPath = this.Model.SuccessFolderPath
                .ToReactivePropertyAsSynchronized(x => x.Value)
                .AddTo(this.Disposables);

            this.RetryIntervalSec = this.Model.RetryIntervalSec
                .ToReactivePropertyAsSynchronized(x => x.Value)
                .AddTo(this.Disposables);

            this.CanReturn = this.Model.CanReturn
                .ToReactivePropertyAsSynchronized(x => x.Value)
                .AddTo(this.Disposables);

            this.CanSave = this.Model.CanSave
                .ToReactivePropertyAsSynchronized(x => x.Value)
                .AddTo(this.Disposables);

            this.Setting = this.Model.Setting
                .ToReactivePropertyAsSynchronized(x => x.Value)
                .AddTo(this.Disposables);

            this.ReturnCommand = this.CanReturn.ToReactiveCommand().WithSubscribe(() => this.Return());
            this.SaveCommand = this.CanSave.ToReactiveCommand().WithSubscribe(() => this.Save());

            // RaisePropertyChanged のパラメータに null か string.Empty をセットすると
            //全プロパティを一括で呼び出す⇒VとVMをつなげた後に一括で画面の更新する必要がある
            this.RaisePropertyChanged(null);
        }

        private void Return()
        {
            this.Model.Return();
        }

        private void Save()
        {
            this.Model.Save();
        }

        private void SetCanButton()
        {
            this.Model.SetButton(true);
        }

        private void ToLogin()
        {
            var model = new LoginModel(this.Setting.Value);
            var param = new Prism.Regions.NavigationParameters();
            param.Add("Model", model);
            this.RegionManager.RequestNavigate("ContentRegion", this.ViewManager.Login, param);
        }

        private void ToMenu()
        {
            var model = new MenuModel(this.Setting.Value);
            var param = new Prism.Regions.NavigationParameters();
            param.Add("Model", model);
            this.RegionManager.RequestNavigate("ContentRegion", this.ViewManager.Menu, param);
        }
    }
}