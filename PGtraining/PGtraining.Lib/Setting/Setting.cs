namespace PGtraining.Lib.Setting
{
    static public class Setting
    {
        static public string ConnectionString { get; set; }
            = @"Data Source=DESKTOP-422HNHF\SQLEXPRESS;Initial Catalog = PGtraningRis; User ID = sa; Password=us@dmin";

        static public string ImportFolderPath { get; set; }
            = @"C:\Users\Yoshikuni\source\repos\PGtraining\PGtraining\sample";

        static public string LogFolderPath { get; set; }
            = @"C:\testLog";

        static public string SuccessFolderPath { get; set; }
            = @"C:\testLog\success";

        static public string ErrorFolderPath { get; set; }
            = @"C:\testLog\error";
    }
}