using PGtraining.Lib.DB;
using PGtraining.Lib.Setting;
using Prism.Mvvm;
using Reactive.Bindings;

namespace PGtraining.RisMenu.Model
{
    public class LoginModel : BindableBase
    {
        public ReactiveProperty<string> UserId { get; }
        public ReactiveProperty<string> PassWord { get; }
        public ReactiveProperty<string> ErrorMessage { get; }

        private Setting Setting = null;

        public LoginModel(Setting setting)
        {
            this.Setting = setting;

            this.UserId = new ReactiveProperty<string>();
            this.PassWord = new ReactiveProperty<string>();
            this.ErrorMessage = new ReactiveProperty<string>();
        }

        public bool Check()
        {
            var result = false;
            var user = Sql.GetUsers(this.UserId.Value, this.Setting);
            if (user.PassWord == this.PassWord.Value)
            {
                result = true;
            }
            else
            {
                result = false;
                this.PassWord.Value = "";
                this.ErrorMessage.Value = "ユーザIdとパスワードが一致しません。";
            }
            return result;
        }
    }
}