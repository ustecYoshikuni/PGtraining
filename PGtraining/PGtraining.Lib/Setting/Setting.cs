namespace PGtraining.Lib.Setting
{
    public class Setting
    {
        /// <summary>
        /// 接続文字列
        /// </summary>
        public string ConnectionString { get; set; }
            = @"Data Source=DESKTOP-422HNHF\SQLEXPRESS;Initial Catalog = PGtraningRis; User ID = sa; Password=us@dmin";

        /// <summary>
        /// 監視対象フォルダのパス
        /// </summary>
        public string ImportFolderPath { get; set; }
            = @"C:\Users\Yoshikuni\source\repos\PGtraining\PGtraining\sample";

        /// <summary>
        /// ファイル名のパターン
        /// </summary>
        public string FileNamePattern { get; set; }
            = @"*.csv";

        /// <summary>
        /// 処理間隔期間
        /// </summary>
        public int IntervalSec { get; set; }
            = 10;

        /// <summary>
        /// 再処理間隔
        /// </summary>
        public int RetryIntervalSec { get; set; }
            = 3;

        /// <summary>
        /// 再処理回数
        /// </summary>
        public int RetryCount { get; set; }
            = 3;

        /// <summary>
        /// ログ出力フォルダのパス
        /// </summary>
        public string LogFolderPath { get; set; }
            = @"C:\testLog";

        /// <summary>
        /// 成功フォルダのパス
        /// </summary>
        public string SuccessFolderPath { get; set; }
            = @"C:\testLog\success";

        /// <summary>
        /// エラーフォルダのパス
        /// </summary>
        public string ErrorFolderPath { get; set; }
            = @"C:\testLog\error";

        public bool CanAutoReload { get; set; }
            = false;

        public int AutoReloadTime { get; set; }
            = 30;

        /// <summary>
        /// 値が同じか判定
        /// true:同じ false:異なる
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null || this.GetType() != obj.GetType())
            {
                return false;
            }

            Setting c = (Setting)obj;

            return (this.ErrorFolderPath == c.ErrorFolderPath) && (this.FileNamePattern == c.FileNamePattern) && (this.ImportFolderPath == c.ImportFolderPath)
                && (this.IntervalSec == c.IntervalSec) && (this.LogFolderPath == c.LogFolderPath) && (this.RetryCount == c.RetryCount) && (this.RetryIntervalSec == c.RetryIntervalSec)
                && (this.SuccessFolderPath == c.SuccessFolderPath) && (this.CanAutoReload == c.CanAutoReload) && (this.AutoReloadTime == this.AutoReloadTime);
        }

        public override int GetHashCode()
        {
            throw new System.NotImplementedException();
        }
    }
}