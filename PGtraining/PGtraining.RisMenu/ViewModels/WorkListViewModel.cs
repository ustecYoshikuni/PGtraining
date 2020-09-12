using PGtraining.Lib.Import;
using PGtraining.Lib.Log;
using PGtraining.Lib.Setting;
using Prism.Mvvm;
using Prism.Regions;
using Reactive.Bindings;
using System.IO;
using static PGtraining.Lib.Log.LogLeverl;

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

        private Log Log = new Log();

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
            this.Log.Write($"フォルダ読込開始：{Setting.ImportFolderPath}", LevelEnum.INFO);

            var csvImport = new CsvImport();
            var files = Directory.GetFiles(Setting.ImportFolderPath);
            foreach (var file in files)
            {
                var result = csvImport.Import(file);

                if (result)
                {
                    this.Log.Write($"ファイル読込成功：{file}", LevelEnum.INFO);
                    var success = $"{Setting.SuccessFolderPath}\\{Path.GetFileName(file)}";

                    File.Copy(file, success, true);
                }
                else
                {
                    this.Log.Write($"ファイル読込失敗：{file}", LevelEnum.INFO);
                    var success = $"{Setting.ErrorFolderPath}\\{Path.GetFileName(file)}";

                    File.Copy(file, success, true);
                }
            }
        }
    }
}