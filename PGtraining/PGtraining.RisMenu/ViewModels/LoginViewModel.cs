using PGtraining.Lib.Setting;
using PGtraining.RisMenu.Model;
using Prism.Mvvm;
using Prism.Regions;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;

namespace PGtraining.RisMenu.ViewModels
{
    public class LoginViewModel : BindableBase, INavigationAware
    {
        public ReactiveProperty<string> UserId { get; set; }
        public ReactiveProperty<string> PassWord { get; set; }
        public ReactiveProperty<string> ErrorMessage { get; set; }
        public ReactiveCommand<object> LoginCommand { get; set; }

        private IRegionManager RegionManager { get; set; }
        private IRegionNavigationService RegionNavigationService { get; set; }

        private ViewManager ViewManager;
        private Setting Setting = null;
        private LoginModel Model = null;
        private System.Reactive.Disposables.CompositeDisposable Disposables = new System.Reactive.Disposables.CompositeDisposable();

        public LoginViewModel()
        {
        }

        public LoginViewModel(IRegionManager regionManager, ViewManager viewManager, Setting setting)
        {
            this.RegionManager = regionManager;
            this.ViewManager = viewManager;
            this.Setting = setting;

            this.UserId = new ReactiveProperty<string>();
            this.PassWord = new ReactiveProperty<string>();
            this.ErrorMessage = new ReactiveProperty<string>();
            this.Model = new LoginModel(setting);
            this.LoginCommand = new ReactiveCommand<object>().WithSubscribe(x => this.Login(x));

            this.ModelViewModelConnect();
        }

        #region '画面遷移'

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            this.RegionNavigationService = navigationContext.NavigationService;
            this.Model = navigationContext.Parameters["Model"] as LoginModel;
            this.Setting = this.Model.Setting;

            this.ModelViewModelConnect();
        }

        private void ModelViewModelConnect()
        {
            this.UserId = this.Model.UserId
                .ToReactivePropertyAsSynchronized(x => x.Value)
                .AddTo(this.Disposables);

            this.PassWord = this.Model.PassWord
                .ToReactivePropertyAsSynchronized(x => x.Value)
                .AddTo(this.Disposables);

            this.ErrorMessage = this.Model.ErrorMessage
                .ToReactivePropertyAsSynchronized(x => x.Value)
                .AddTo(this.Disposables);

            // RaisePropertyChanged のパラメータに null か string.Empty をセットすると
            //全プロパティを一括で呼び出す⇒VとVMをつなげた後に一括で画面の更新する必要がある
            this.RaisePropertyChanged(null);
        }

        public bool IsNavigationTarget(NavigationContext navigationContext) => true;

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        #endregion '画面遷移'

        public void Login(object x)
        {
            var passwordBox = x as System.Windows.Controls.PasswordBox;
            this.PassWord.Value = passwordBox.Password;
            if (this.Model.Check())
            {
                this.ToMenu();
            }
        }

        public void ToMenu()
        {
            var model = new MenuModel(this.Setting);
            var param = new Prism.Regions.NavigationParameters();
            param.Add("Model", model);
            this.RegionManager.RequestNavigate("ContentRegion", this.ViewManager.Menu, param);
        }
    }
}