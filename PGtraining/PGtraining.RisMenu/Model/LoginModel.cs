using PGtraining.Lib.DB;
using Prism.Mvvm;
using Reactive.Bindings;

namespace PGtraining.RisMenu.Model
{
    public class LoginModel : BindableBase
    {
        public ReactiveProperty<string> UserId { get; }
        public ReactiveProperty<string> PassWord { get; }
        public ReactiveProperty<string> ErrorMessage { get; }

        public LoginModel()
        {
            this.UserId = new ReactiveProperty<string>();
            this.PassWord = new ReactiveProperty<string>();
            this.ErrorMessage = new ReactiveProperty<string>();
        }

        public bool Check()
        {
            var result = false;
            var user = Sql.GetUsers(this.UserId.Value);
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