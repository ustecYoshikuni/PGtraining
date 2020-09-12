using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PGtraining.Lib.Import
{
    public class CsvImport
    {
        public List<Template> OrderLists = new List<Template>();

        public bool Import(string filePath)
        {
            var result = false;

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            StreamReader sr = new StreamReader(filePath, System.Text.Encoding.GetEncoding("Shift_JIS"));
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
                        //読込エラー
                    }

                    if (this.CheckOrder(order))
                    {
                    }
                    else
                    {
                        //不正データ
                    }
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
    }
}