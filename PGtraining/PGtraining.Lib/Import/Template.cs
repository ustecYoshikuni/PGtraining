using System.Collections.Generic;

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

        public void Check()
        {
            for (var i = 0; i < this.ElementCount; i++)
            {
            }
        }
    }
}