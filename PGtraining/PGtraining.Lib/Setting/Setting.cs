using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

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

        public Setting()
        {
            this.Read();
        }

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

        public void Read()
        {
            if (File.Exists(Properties.Resources.SettingFilePath))
            {
                XElement xml = XElement.Load(Properties.Resources.SettingFilePath);
                IEnumerable<XElement> infos = from item in xml.Elements("setting") select item;
                foreach (var info in infos)
                {
                    this.AutoReloadTime = int.Parse(info.Element("AutoReloadTime").Value);
                    this.CanAutoReload = bool.Parse(info.Element("CanAutoReload").Value);
                    this.ConnectionString = info.Element("ConnectionString").Value;
                    this.ErrorFolderPath = info.Element("ErrorFolderPath").Value;
                    this.FileNamePattern = info.Element("FileNamePattern").Value;
                    this.ImportFolderPath = info.Element("ImportFolderPath").Value;
                    this.IntervalSec = int.Parse(info.Element("IntervalSec").Value);
                    this.LogFolderPath = info.Element("LogFolderPath").Value;
                    this.RetryCount = int.Parse(info.Element("RetryCount").Value);
                    this.RetryIntervalSec = int.Parse(info.Element("RetryIntervalSec").Value);
                    this.SuccessFolderPath = info.Element("SuccessFolderPath").Value;
                }
            }
        }

        public void Write()
        {
            if (File.Exists(Properties.Resources.SettingFilePath))
            {
                XElement xml = XElement.Load(Properties.Resources.SettingFilePath);
                XElement infos = (from item in xml.Elements("setting") select item).Single();

                infos.Element("AutoReloadTime").Value = this.AutoReloadTime.ToString();
                infos.Element("CanAutoReload").Value = this.CanAutoReload.ToString();
                infos.Element("ConnectionString").Value = this.ConnectionString;
                infos.Element("ErrorFolderPath").Value = this.ErrorFolderPath;
                infos.Element("FileNamePattern").Value = this.FileNamePattern;
                infos.Element("ImportFolderPath").Value = this.ImportFolderPath;
                infos.Element("IntervalSec").Value = this.IntervalSec.ToString();
                infos.Element("LogFolderPath").Value = this.LogFolderPath;
                infos.Element("RetryCount").Value = this.RetryCount.ToString();
                infos.Element("RetryIntervalSec").Value = this.RetryIntervalSec.ToString();
                infos.Element("SuccessFolderPath").Value = this.SuccessFolderPath;

                xml.Save(Properties.Resources.SettingFilePath);
            }
        }
    }
}