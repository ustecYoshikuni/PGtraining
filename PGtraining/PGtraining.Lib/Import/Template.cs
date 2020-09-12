using System.Collections.Generic;
using System.Linq;

namespace PGtraining.Lib.Import
{
    public class Template
    {
        public class Element
        {
            public string Name { get; set; }
            public int Index { get; set; }
            public string Value { get; set; }
            public bool Validate { get; set; }

            public Element(string name, int index)
            {
                this.Name = name;
                this.Index = index;
            }
        }

        public int ElementCount { get; set; } = 11;

        ///// <summary>
        ///// CSVのカラム情報
        ///// カラム数が多い箇所は、すべて最後に入る
        ///// </summary>
        public List<Element> Elements = new List<Element>()
        {
            (new Element("OrderNo", 1)),
            (new Element("StudyDate", 2)),
            (new Element("ProcessingType", 3)),
            (new Element("InspectionType", 4)),
            (new Element("InspectionName", 5)),
            (new Element("PatientId", 6)),
            (new Element("PatientNameKanji", 7)),
            (new Element("PatientNameKana", 8)),
            (new Element("PatientBirth", 9)),
            (new Element("PatientSex", 10)),
            (new Element("Menu", 11)),
        };

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

        public Template()
        { }

        public bool Read(List<string> lists)
        {
            var result = false;

            try
            {
                for (var i = 0; i < lists.Count; i++)
                {
                    if (i < this.ElementCount)
                    {
                        this.Elements[i].Value = lists[i];
                    }
                    else
                    {
                        this.Elements[this.ElementCount - 1].Value = lists[i];
                    }
                }
                result = true;
            }
            catch (System.Exception)
            {
                //ログ出力：読込エラー
            }
            return result;
        }

        public bool CheckAndSet()
        {
            for (var i = 0; i < this.ElementCount; i++)
            {
                var value = this.Elements.Where(x => x.Name == "OrderNo").Select(x => x.Value).First().Trim();
                if ((Check.IsAlphaNumericOnly(value, true, 1, 8)))
                {
                    this.OrderNo = value;
                }
                else
                {
                    // ログ書く
                    return false;
                }

                value = this.Elements.Where(x => x.Name == "StudyDate").Select(x => x.Value).First().Trim();
                if ((Check.IsDateTime(value, "YYYYMMDD")))
                {
                    this.StudyDate = value;
                }
                else
                {
                    // ログ書く
                    return false;
                }

                value = this.Elements.Where(x => x.Name == "ProcessingType").Select(x => x.Value).First().Trim();
                if ((Check.IsMatch(value, "[1 - 3]", true, 1)))
                {
                    this.ProcessingType = value;
                }
                else
                {
                    // ログ書く
                    return false;
                }

                value = this.Elements.Where(x => x.Name == "InspectionType").Select(x => x.Value).First().Trim();
                if ((Check.IsAlphaNumericOnly(value, false, 1, 8)))
                {
                    this.InspectionType = value;
                }
                else
                {
                    // ログ書く
                    return false;
                }

                value = this.Elements.Where(x => x.Name == "InspectionName").Select(x => x.Value).First().Trim();
                if ((Check.IsAlphaNumericOnly(value, false, 1, 32)))
                {
                    this.InspectionName = value;
                }
                else
                {
                    // ログ書く
                    return false;
                }

                value = this.Elements.Where(x => x.Name == "PatientId").Select(x => x.Value).First().Trim();
                if ((Check.IsAlphaNumericOnly(value, true, 1, 10)))
                {
                    this.PatientId = value;
                }
                else
                {
                    // ログ書く
                    return false;
                }

                value = this.Elements.Where(x => x.Name == "PatientNameKanji").Select(x => x.Value).First().Trim();
                if (string.IsNullOrEmpty(value))
                {
                    // ログ書く
                    return false;
                }
                else if (value.Length <= 64)
                {
                    this.PatientNameKanji = value;
                }
                else
                {
                    // ログ書く
                    return false;
                }

                value = this.Elements.Where(x => x.Name == "PatientNameKana").Select(x => x.Value).First().Trim();
                if (Check.IsKataKana(value, false, 1, 64))
                {
                    this.PatientNameKana = value;
                }
                else
                {
                    // ログ書く
                    return false;
                }

                value = this.Elements.Where(x => x.Name == "PatientBirth").Select(x => x.Value).First().Trim();
                if ((Check.IsDateTime(value, "YYYYMMDD")))
                {
                    this.PatientBirth = value;
                }
                else
                {
                    // ログ書く
                    return false;
                }

                value = this.Elements.Where(x => x.Name == "PatientSex").Select(x => x.Value).First().Trim();
                if ((Check.IsMatch(value, "[FMO]", true, 1)))
                {
                    this.PatientSex = value;
                }
                else
                {
                    // ログ書く
                    return false;
                }

                value = this.Elements.Where(x => x.Name == "Menu").Select(x => x.Value).First().Trim() ;
                if (string.IsNullOrEmpty(value))
                {
                    // ログ書く
                    return false;
                }
                else if ((3 < value.Length)&&(value.Contains(",")))
                {
                    this.Menu = value;

                }
                else
                {
                    // ログ書く
                    return false;
                }
            }

            return true;
        }

        private bool SetAndCheckMenu(string menu)
        {
            var result = false;








            return result;
        }



    }
}