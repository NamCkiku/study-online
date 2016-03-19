namespace StudyOnline.Entities.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Comment")]
    public partial class Comment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ID { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [Column(TypeName = "ntext")]
        public string Content { get; set; }

        public DateTime? CreateDate { get; set; }

        [StringLength(500)]
        public string Avatar { get; set; }

        public bool? Status { get; set; }

        public long? UserID { get; set; }

        public long? LessonID { get; set; }

        public int? ParentID { get; set; }

        //public virtual Lesson Lesson { get; set; }
    }
}
