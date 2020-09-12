using System.Collections.Generic;
using System.IO;
using System.Text;
using static PGtraining.Lib.Log.LogLeverl;

namespace PGtraining.Lib.Import
{
    public class CsvImport
    {
        public List<Template> OrderLists = new List<Template>();

        private Log.Log Log = new Lib.Log.Log();

        public bool Import(string filePath)
        {
            this.Log.Write($"Import({filePath})", LevelEnum.INFO);

            var result = false;

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var sr = new StreamReader(filePath, System.Text.Encoding.GetEncoding("Shift_JIS"));
            {
                //ヘッダ分
                sr.ReadLine();

                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] values = line.Split(',');

                    List<string> lists = new List<string>();

                    //""の除去
                    for (var i = 0; i < values.Length; i++)
                    {
                        var text = values[i].Substring(1, values[i].Length - 2);
                        lists.Add(text);
                    }

                    var order = new Template();
                    if (this.ReadOrder(order, lists))
                    {
                    }
                    else
                    {
                        //ログ出力：読込エラー
                        this.Log.Write("読込失敗", LevelEnum.ERRROR);
                        continue;
                    }

                    if (this.CheckOrder(order))
                    {
                    }
                    else
                    {
                        //不正データ
                        this.Log.Write("データが不正", LevelEnum.ERRROR);
                        continue;
                    }

                    if (this.DbInsertOrUpdate(order))
                    {
                    }
                    else
                    {
                        //登録失敗
                        this.Log.Write("DBの登録に失敗", LevelEnum.ERRROR);
                        continue;
                    }
                    result = true;
                }
            }
            return result;
        }

        private bool ReadOrder(Template order, List<string> lists)
        {
            return order.Read(lists);
        }

        private bool CheckOrder(Template order)
        {
            return order.CheckAndSet();
        }

        private bool DbInsertOrUpdate(Template order)
        {
            var result = false;

            if (DB.Sql.HasOrderNo(order.Order))
            {
                try
                {
                    DB.Sql.UpdateOrder(order);
                    result = true;
                }
                catch (System.Exception ex)
                {
                    this.Log.Write(ex.ToString(), LevelEnum.ERRROR);
                }
            }
            else
            {
                try
                {
                    DB.Sql.InsertOrder(order);
                    result = true;
                }
                catch (System.Exception ex)
                {
                    this.Log.Write(ex.ToString(), LevelEnum.ERRROR);
                }
            }

            return result;
        }
    }
}