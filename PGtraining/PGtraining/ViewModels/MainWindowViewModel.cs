using Prism.Mvvm;

namespace PGtraining.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "PGtraining Ris";

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel()
        {
        }
    }
}