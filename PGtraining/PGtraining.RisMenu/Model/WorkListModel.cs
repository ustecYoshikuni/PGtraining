using PGtraining.Lib.DB;
using PGtraining.Lib.Import;
using PGtraining.Lib.Log;
using PGtraining.Lib.Setting;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using static PGtraining.Lib.Log.LogLeverl;

namespace PGtraining.RisMenu.Model
{
    public class WorkListModel : BindableBase
    {
        public ObservableCollection<OrderModel> WorkList { get; } = new ObservableCollection<OrderModel>();
        public Setting Setting = null;
        private Log Log = new Log();

        public WorkListModel(Setting setting)
        {
            this.Setting = setting;
            this.SetWorkList();
        }

        public void SetWorkList()
        {
            var orders = Sql.GetOrders(this.Setting);

            this.WorkList.AddRange(orders.Select(x => new OrderModel(x)));
        }

        public void Import()
        {
            this.Log.Write($"フォルダ読込開始：{this.Setting.ImportFolderPath}", LevelEnum.INFO, this.Setting.LogFolderPath);

            var csvImport = new CsvImport();
            var files = Directory.GetFiles(Setting.ImportFolderPath);
            foreach (var file in files)
            {
                var result = csvImport.Import(file, this.Setting);

                if (result)
                {
                    this.Log.Write($"ファイル読込成功：{file}", LevelEnum.INFO, this.Setting.LogFolderPath);
                    var success = $"{Setting.SuccessFolderPath}\\{Path.GetFileName(file)}";

                    File.Copy(file, success, true);
                }
                else
                {
                    this.Log.Write($"ファイル読込失敗：{file}", LevelEnum.INFO, this.Setting.LogFolderPath);
                    var success = $"{Setting.ErrorFolderPath}\\{Path.GetFileName(file)}";

                    File.Copy(file, success, true);
                }
            }
        }
    }
}