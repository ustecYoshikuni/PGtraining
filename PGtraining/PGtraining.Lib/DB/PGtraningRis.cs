using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PGtraining.Lib.DB
{
    /// <summary>
    /// A class which represents the Menu table.
    /// </summary>
    [Table("Menu")]
    public partial class Menu
    {
        [Key]
        public virtual int Id { get; set; }

        public virtual string OrderNo { get; set; }
        public virtual string MenuCode { get; set; }
        public virtual string MenuName { get; set; }
    }

    /// <summary>
    /// A class which represents the Orders table.
    /// </summary>
    [Table("Orders")]
    public partial class Order
    {
        public virtual int Id { get; set; }

        [Key]
        public virtual string OrderNo { get; set; }

        public virtual string StudyDate { get; set; }
        public virtual string ProcessingType { get; set; }
        public virtual string InspectionType { get; set; }
        public virtual string InspectionName { get; set; }
        public virtual string PatientId { get; set; }
        public virtual string PatientNameKanji { get; set; }
        public virtual string PatientNameKana { get; set; }
        public virtual string PatientBirth { get; set; }
        public virtual string PatientSex { get; set; }
    }

    /// <summary>
    /// A class which represents the Users table.
    /// </summary>
    [Table("Users")]
    public partial class User
    {
        public virtual int Id { get; set; }

        [Key]
        public virtual string UserId { get; set; }

        public virtual string Name { get; set; }
        public virtual string PassWord { get; set; }
        public virtual string ExpirationDate { get; set; }
    }

    /// <summary>
    /// A class which represents the OrderView view.
    /// </summary>
    [Table("OrderView")]
    public partial class OrderView
    {
        public virtual string OrderNo { get; set; }
        public virtual string StudyDate { get; set; }
        public virtual string ProcessingType { get; set; }
        public virtual string InspectionType { get; set; }
        public virtual string InspectionName { get; set; }
        public virtual string PatientId { get; set; }
        public virtual string PatientNameKanji { get; set; }
        public virtual string PatientNameKana { get; set; }
        public virtual string PatientBirth { get; set; }
        public virtual string PatientSex { get; set; }
        public virtual string MenuCodes { get; set; }
        public virtual string MenuNames { get; set; }
    }
}