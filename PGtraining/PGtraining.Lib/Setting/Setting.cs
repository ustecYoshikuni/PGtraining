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
    }
}