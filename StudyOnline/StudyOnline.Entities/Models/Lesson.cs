namespace StudyOnline.Entities.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Lesson")]
    public partial class Lesson
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public Lesson()
        //{
        //    AttachMent = new HashSet<AttachMent>();
        //    Comment = new HashSet<Comment>();
        //    Video = new HashSet<Video>();
        //}

        public long ID { get; set; }

        [StringLength(250)]
        public string LessonName { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public DateTime? CreateDate { get; set; }

        public bool? Status { get; set; }

        public long? SectionID { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<AttachMent> AttachMent { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Comment> Comment { get; set; }

        //public virtual Section Section { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Video> Video { get; set; }
    }
}
