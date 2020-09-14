using PGtraining.Lib.DB;
using Prism.Mvvm;
using Reactive.Bindings;

namespace PGtraining.RisMenu.Model
{
    public class OrderModel : BindableBase
    {
        public ReactiveProperty<string> OrderNo { get; } = new ReactiveProperty<string>();
        public ReactiveProperty<string> StudyDate { get; } = new ReactiveProperty<string>();
        public ReactiveProperty<string> ProcessingType { get; } = new ReactiveProperty<string>();
        public ReactiveProperty<string> InspectionType { get; } = new ReactiveProperty<string>();
        public ReactiveProperty<string> InspectionName { get; } = new ReactiveProperty<string>();
        public ReactiveProperty<string> PatientId { get; } = new ReactiveProperty<string>();
        public ReactiveProperty<string> PatientNameKanji { get; } = new ReactiveProperty<string>();
        public ReactiveProperty<string> PatientNameKana { get; } = new ReactiveProperty<string>();
        public ReactiveProperty<string> PatientBirth { get; } = new ReactiveProperty<string>();
        public ReactiveProperty<string> PatientSex { get; } = new ReactiveProperty<string>();
        public ReactiveProperty<string> MenuCodes { get; } = new ReactiveProperty<string>();
        public ReactiveProperty<string> MenuNames { get; } = new ReactiveProperty<string>();

        public OrderModel(OrderView orderView)
        {
            this.OrderNo.Value = orderView.OrderNo;

            var studydate = (string.IsNullOrEmpty(orderView.StudyDate)) ? "00000000" : orderView.StudyDate;
            this.StudyDate.Value = $"{studydate.Substring(0, 4)}/{studydate.Substring(4, 2)}/{studydate.Substring(6, 2)}";

            this.ProcessingType.Value = orderView.ProcessingType;
            this.InspectionType.Value = orderView.InspectionType;
            this.InspectionName.Value = orderView.InspectionName;
            this.PatientId.Value = orderView.PatientId;
            this.PatientNameKanji.Value = orderView.PatientNameKanji;
            this.PatientNameKana.Value = orderView.PatientNameKana;

            var birth = (string.IsNullOrEmpty(orderView.PatientBirth)) ? "00000000" : orderView.PatientBirth;
            this.PatientBirth.Value = $"{birth.Substring(0, 4)}/{birth.Substring(4, 2)}/{birth.Substring(6, 2)}";

            this.PatientSex.Value = orderView.PatientSex;
            this.MenuCodes.Value = orderView.MenuCodes;
            this.MenuNames.Value = orderView.MenuNames;
        }
    }
}