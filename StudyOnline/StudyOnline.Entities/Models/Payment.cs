namespace StudyOnline.Entities.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Payment")]
    public partial class Payment
    {
        public int ID { get; set; }

        public int? QuantityCoin { get; set; }

        public DateTime? HistoryTrade { get; set; }

        public bool? Status { get; set; }

        public long? UserID { get; set; }

        public virtual User User { get; set; }
    }
}
