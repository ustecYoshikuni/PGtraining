using System.Collections.Generic;
using System.IO;

namespace PGtraining.Lib.Import
{
    public class Template
    {
        public string OrderNo { get; set; }
        public string StudyDate { get; set; }
        public string ProcessingType { get; set; }
        public string InspectionType { get; set; }
        public string InspectionName { get; set; }
        public string PatientId { get; set; }
        public string PatientNameKanji { get; set; }
        public string PatientNameKana { get; set; }
        public string PatientBirth { get; set; }
        public string PatientSex { get; set; }
        public string Menu { get; set; }
        public List<string> MenuCodes { get; set; } = new List<string>();
        public List<string> MenuName { get; set; } = new List<string>();

        public bool Import(string filePath)
        {
            var result = false;

            StreamReader sr = new StreamReader(filePath, System.Text.Encoding.GetEncoding("shift_jis"));
            {
                //ヘッダ分
                sr.ReadLine();

                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] values = line.Split(',');

                    List<string> lists = new List<string>();
                    lists.AddRange(values);
                    lists.ForEach(x => x.Substring(1, x.Length - 2));
                }
            }

            return result;
        }

        private bool CsvCheck()
        {
            var result = false;

            return result;
        }
    }
}