using PGtraining.Lib.Setting;
using Prism.Mvvm;
using Reactive.Bindings;

namespace PGtraining.RisMenu.Model
{
    public class SettingModel : BindableBase
    {
        /// <summary>
        /// 監視対象フォルダのパス
        /// </summary>
        public ReactiveProperty<string> ImportFolderPath { get; } = new ReactiveProperty<string>();

        /// <summary>
        /// ファイル名のパターン
        /// </summary>
        public ReactiveProperty<string> FileNamePattern { get; } = new ReactiveProperty<string>();

        /// <summary>
        /// 処理間隔期間
        /// </summary>
        public ReactiveProperty<int> IntervalSec { get; } = new ReactiveProperty<int>();

        /// <summary>
        /// 再処理間隔
        /// </summary>
        public ReactiveProperty<int> RetryIntervalSec { get; } = new ReactiveProperty<int>();

        /// <summary>
        /// 再処理回数
        /// </summary>
        public ReactiveProperty<int> RetryCount { get; } = new ReactiveProperty<int>();

        /// <summary>
        /// ログ出力フォルダのパス
        /// </summary>
        public ReactiveProperty<string> LogFolderPath { get; } = new ReactiveProperty<string>();

        /// <summary>
        /// 成功フォルダのパス
        /// </summary>
        public ReactiveProperty<string> SuccessFolderPath { get; } = new ReactiveProperty<string>();

        /// <summary>
        /// エラーフォルダのパス
        /// </summary>
        public ReactiveProperty<string> ErrorFolderPath { get; } = new ReactiveProperty<string>();

        public SettingModel(Setting setting)
        {
            this.ErrorFolderPath.Value = setting.ErrorFolderPath;
            this.FileNamePattern.Value = setting.FileNamePattern;
            this.ImportFolderPath.Value = setting.ImportFolderPath;
            this.IntervalSec.Value = setting.IntervalSec;
            this.LogFolderPath.Value = setting.LogFolderPath;
            this.RetryCount.Value = setting.RetryCount;
            this.RetryIntervalSec.Value = setting.RetryIntervalSec;
            this.SuccessFolderPath.Value = setting.SuccessFolderPath;
        }
    }
}