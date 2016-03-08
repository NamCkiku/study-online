namespace StudyOnline.Entities.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Video")]
    public partial class Video
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ID { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(250)]
        public string Link { get; set; }

        public TimeSpan? Length { get; set; }

        public DateTime? CreateDate { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public bool? Status { get; set; }

        public long? LessonID { get; set; }

        public virtual Lesson Lesson { get; set; }
    }
}
