namespace StudyOnline.Entities.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Attachment")]
    public partial class Attachment
    {
        public long ID { get; set; }

        [StringLength(500)]
        public string FileName { get; set; }

        [StringLength(500)]
        public string Path { get; set; }

        public int? Type { get; set; }

        public DateTime? CreateDate { get; set; }

        public bool? Status { get; set; }

        public long? LessonID { get; set; }

        public virtual Lesson Lesson { get; set; }
    }
}
