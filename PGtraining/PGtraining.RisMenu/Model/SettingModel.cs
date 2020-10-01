using PGtraining.Lib.Setting;
using Prism.Mvvm;
using Reactive.Bindings;
using System;
using System.Reactive.Disposables;

namespace PGtraining.RisMenu.Model
{
    public class SettingModel : BindableBase, IDisposable
    {
        public ReactiveProperty<bool> CanReturn { get; } = new ReactiveProperty<bool>(false);
        public ReactiveProperty<bool> CanSave { get; } = new ReactiveProperty<bool>(false);

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

        public ReactiveProperty<Setting> Setting { get; } = new ReactiveProperty<Setting>();

        private Setting BackUpSetting = null;

        protected CompositeDisposable Disposables = new CompositeDisposable();

        public SettingModel(Setting setting)
        {
            this.SetValue(setting);

            this.CanSave.Value = true;
            this.CanReturn.Value = true;
        }

        private void SetValue(Setting setting)
        {
            this.Setting.Value = setting;
            this.BackUpSetting = setting;

            this.ErrorFolderPath.Value = setting.ErrorFolderPath;
            this.FileNamePattern.Value = setting.FileNamePattern;
            this.ImportFolderPath.Value = setting.ImportFolderPath;
            this.IntervalSec.Value = setting.IntervalSec;
            this.LogFolderPath.Value = setting.LogFolderPath;
            this.RetryCount.Value = setting.RetryCount;
            this.RetryIntervalSec.Value = setting.RetryIntervalSec;
            this.SuccessFolderPath.Value = setting.SuccessFolderPath;
        }

        public void Return()
        {
            this.SetValue(this.BackUpSetting);
        }

        public void Save()
        {
            var newSetting = this.SetSetting();
            this.SetValue(newSetting);
        }

        private Setting SetSetting()
        {
            var setting = new Setting
            {
                ErrorFolderPath = this.ErrorFolderPath.Value,
                FileNamePattern = this.FileNamePattern.Value,
                ImportFolderPath = this.ImportFolderPath.Value,
                IntervalSec = this.IntervalSec.Value,
                LogFolderPath = this.LogFolderPath.Value,
                RetryCount = this.RetryCount.Value,
                RetryIntervalSec = this.RetryIntervalSec.Value,
                SuccessFolderPath = this.SuccessFolderPath.Value
            };
            return setting;
        }

        public void ChangeAction()
        {
            var diff = this.HasDiff();
            this.CanReturn.Value = diff;
            this.CanSave.Value = diff;
        }

        public void SetButton(bool canButton)
        {
            this.CanReturn.Value = canButton;
            this.CanSave.Value = canButton;
        }

        private bool HasDiff()
        {
            var newSetting = this.SetSetting();
            return !(newSetting.Equals(this.Setting));
        }

        public void Dispose()
        {
            this.Disposables.Dispose();
        }
    }
}