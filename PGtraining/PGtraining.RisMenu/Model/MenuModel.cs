using PGtraining.Lib.Setting;
using Prism.Mvvm;

namespace PGtraining.RisMenu.Model
{
    public class MenuModel : BindableBase
    {
        public Setting Setting = null;

        public MenuModel(Setting setting)
        {
            this.Setting = setting;
        }
    }
}