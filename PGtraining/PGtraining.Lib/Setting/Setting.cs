namespace PGtraining.Lib.Setting
{
    static public class Setting
    {
        /// <summary>
        /// 接続文字列
        /// </summary>
        static public string ConnectionString { get; set; }
            = @"Data Source=DESKTOP-422HNHF\SQLEXPRESS;Initial Catalog = PGtraningRis; User ID = sa; Password=us@dmin";

        /// <summary>
        /// 監視対象フォルダのパス
        /// </summary>
        static public string ImportFolderPath { get; set; }
            = @"C:\Users\Yoshikuni\source\repos\PGtraining\PGtraining\sample";

        /// <summary>
        /// ファイル名のパターン
        /// </summary>
        static public string FileNamePattern { get; set; }
            = @"*.csv";

        /// <summary>
        /// 処理間隔期間
        /// </summary>
        static public int IntervalSec { get; set; }
            = 10;

        /// <summary>
        /// 再処理間隔
        /// </summary>
        static public int RetryIntervalSec { get; set; }
            = 3;

        /// <summary>
        /// 再処理回数
        /// </summary>
        static public int RetryCount { get; set; }
            = 3;

        /// <summary>
        /// ログ出力フォルダのパス
        /// </summary>
        static public string LogFolderPath { get; set; }
            = @"C:\testLog";

        /// <summary>
        /// 成功フォルダのパス
        /// </summary>
        static public string SuccessFolderPath { get; set; }
            = @"C:\testLog\success";

        /// <summary>
        /// エラーフォルダのパス
        /// </summary>
        static public string ErrorFolderPath { get; set; }
            = @"C:\testLog\error";
    }
}