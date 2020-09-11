using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PGtraining.Lib.Import
{
    public class CsvImport
    {
        public Template CsvFile = new Template();

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

                    this.CheckAndSet(lists);
                }
            }

            return result;
        }

        private bool CheckAndSet(List<string> lists)
        {
            var result = false;

            for (var i = 0; i < lists.Count; i++)
            {
                if (i <= this.CsvFile.ElementCount)
                {
                    this.CsvFile.Elements[i].Value = lists[i];
                }
                else
                {
                    this.CsvFile.Elements[this.CsvFile.ElementCount - 1].Value = lists[i];
                }
            }

            return result;
        }

        private bool CsvCheck(List<string> lists)
        {
            var result = false;

            return result;
        }
    }
}