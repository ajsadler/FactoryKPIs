using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FactoryKPIs.Data
{
    [Table("T3_ProductionOrder", Schema = "dbo")]
    public class ProductionOrder
    {
        [Key]
        public long IdNo { get; set; }
        public string OrderNo { get; set; } = null!;
        public int? OrderPos { get; set; }
        [Column("Level")]
        public int Level { get; set; }
        public string ParentOrderNo { get; set; } = null!;
        public long? ParentOrderIdNo { get; set; }
        public string ParentOrderOperationNo { get; set; } = null!;
        public string HeadOrderNo { get; set; } = null!;
        public long? HeadOrderIdNo { get; set; }
        public string Material { get; set; } = null!;
        public string MaterialDescription { get; set; } = null!;
        public long Quantity { get; set; }
        public string Unit { get; set; } = null!;
        public long LocalQuantity { get; set; }
        public string LocalUnit { get; set; } = null!;
        public string BatchNo { get; set; } = null!;
        public string SpecialStock { get; set; } = null!;
        public string CustomerOrderNo { get; set; } = null!;
        public string CustomerOrderItemNo { get; set; } = null!;
        public string? ReservationPlanNr { get; set; } = null!;
        public string ProductionProgram { get; set; } = null!;
        public long? ProductionProgramIdNo { get; set; }
        public long OrderSequence { get; set; }
        public DateTime StartTs { get; set; }
        public DateTime EndTs { get; set; }
        public string ReservationNo { get; set; } = null!;
        public int State { get; set; }
        public DateTime StateTs { get; set; }
        public string StateUser { get; set; } = null!;
        public DateTime InsertTs { get; set; }
        public string InsertUser { get; set; } = null!;
        public DateTime UpdateTs { get; set; }
        public string UpdateUser { get; set; } = null!;
        public long? ImportJobId { get; set; }
    }
}
