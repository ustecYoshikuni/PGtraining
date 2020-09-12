using System.Collections.Generic;
using System.Linq;
using static PGtraining.Lib.Log.LogLeverl;

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
        public List<string> MenuNames { get; set; } = new List<string>();

        private Log.Log Log = new Log.Log();

        public Template()
        {
        }

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
            catch (System.Exception ex)
            {
                //ログ出力：読込エラー
                this.Log.Write(ex.ToString(), LevelEnum.CRITICAL);
            }
            return result;
        }

        public bool CheckAndSet()
        {
            this.Log.Write($"CheckAndSet() start", LevelEnum.INFO);

            for (var i = 0; i < this.ElementCount; i++)
            {
                var value = this.Elements.Where(x => x.Name == "OrderNo").Select(x => x.Value).First().Trim();
                if ((Check.IsAlphaNumericOnly(value, true, 1, 8)))
                {
                    this.OrderNo = value;
                    this.Log.Write($"OrderNo:{value}", LevelEnum.INFO);
                }
                else
                {
                    // ログ書く
                    this.Log.Write($"OrderNo:値が不正です。", LevelEnum.ERRROR);
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
                    this.Log.Write($"StudyDate:値が不正です。", LevelEnum.ERRROR);
                    return false;
                }

                value = this.Elements.Where(x => x.Name == "ProcessingType").Select(x => x.Value).First().Trim();
                if ((Check.IsMatch(value, "[123]", true, 1)))
                {
                    this.ProcessingType = value;
                }
                else
                {
                    // ログ書く
                    this.Log.Write($"ProcessingType:値が不正です。", LevelEnum.ERRROR);
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
                    this.Log.Write($"InspectionType:値が不正です。", LevelEnum.ERRROR);
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
                    this.Log.Write($"InspectionName:値が不正です。", LevelEnum.ERRROR);
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
                    this.Log.Write($"PatientId:値が不正です。", LevelEnum.ERRROR);
                    return false;
                }

                value = this.Elements.Where(x => x.Name == "PatientNameKanji").Select(x => x.Value).First().Trim();
                if (string.IsNullOrEmpty(value))
                {
                    // ログ書く
                    this.Log.Write($"PatientNameKanji:値が不正です。", LevelEnum.ERRROR);
                    return false;
                }
                else if (value.Length <= 64)
                {
                    this.PatientNameKanji = value;
                }
                else
                {
                    // ログ書く
                    this.Log.Write($"PatientNameKanji:値が不正です。", LevelEnum.ERRROR);
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
                    this.Log.Write($"PatientNameKana:値が不正です。", LevelEnum.ERRROR);
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
                    this.Log.Write($"PatientBirth:値が不正です。", LevelEnum.ERRROR);
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
                    this.Log.Write($"PatientSex:値が不正です。", LevelEnum.ERRROR);
                    return false;
                }

                value = this.Elements.Where(x => x.Name == "Menu").Select(x => x.Value).First();
                if (string.IsNullOrEmpty(value))
                {
                    // ログ書く
                    this.Log.Write($"Menu:値が不正です。", LevelEnum.ERRROR);
                    return false;
                }
                else if ((3 < value.Length) && (this.Menu.Split(',').Length % 2 == 0))
                {
                    this.Menu = value;

                    if (this.SetAndCheckMenu(this.Menu))
                    {
                    }
                    else
                    {
                        this.Log.Write($"Menu:値が不正です。", LevelEnum.ERRROR);

                        return false;
                    }
                }
                else
                {
                    // ログ書く
                    this.Log.Write($"Menu:値が不正です。", LevelEnum.ERRROR);
                    return false;
                }
            }

            return true;
        }

        private bool SetAndCheckMenu(string menu)
        {
            string[] values = menu.Split(',');
            return this.SetMenu(values);
        }

        private bool SetMenu(string[] values)
        {
            var result = false;
            for (var i = 0; i < values.Count() - 1; i = i + 2)
            {
                var code = "";
                var name = "";

                if (i % 2 == 0)
                {
                    var valueCode = values[i];
                    if ((Check.IsAlphaNumericOnly(valueCode, true, 1, 8)))
                    {
                        code = valueCode;
                    }
                    else
                    {
                        result = false;
                        this.Log.Write($"MenuCode:値が不正です。", LevelEnum.ERRROR);
                    }

                    var valueName = values[i + 1];
                    if (Check.IsMatch(valueName, ".*", true, 1, 32))
                    {
                        name = valueName;
                    }
                    else
                    {
                        result = false;
                        this.Log.Write($"MenuName:値が不正です。", LevelEnum.ERRROR);
                    }
                }

                if (!((string.IsNullOrEmpty(code)) && (string.IsNullOrEmpty(name))))
                {
                    this.MenuCodes.Add(code);
                    this.MenuNames.Add(name);

                    result = true;
                }
            }
            return result;
        }
    }
}