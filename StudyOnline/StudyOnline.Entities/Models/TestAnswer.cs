namespace StudyOnline.Entities.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TestAnswer")]
    public partial class TestAnswer
    {
        public long ID { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [Column(TypeName = "ntext")]
        public string TittleAnswer { get; set; }

        public long? TestQuestionID { get; set; }

        //public virtual TestQuestion TestQuestion { get; set; }
    }
}
