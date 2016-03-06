namespace StudyOnline.Entities.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Course")]
    public partial class Course
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Course()
        {
            Sections = new HashSet<Section>();
            User_Study_Course = new HashSet<User_Study_Course>();
            User_Teacher_Course = new HashSet<User_Teacher_Course>();
            Users = new HashSet<User>();
        }

        public long ID { get; set; }

        [StringLength(250)]
        public string CourseName { get; set; }

        [StringLength(250)]
        public string Avatar { get; set; }

        [StringLength(500)]
        public string VideoIntroduce { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Column(TypeName = "ntext")]
        public string Content { get; set; }

        public double? PriceSale { get; set; }

        public double? Price { get; set; }

        public int? ViewCount { get; set; }

        public DateTime? CreateDate { get; set; }

        public string Tags { get; set; }

        public bool? Status { get; set; }

        public bool? TopHot { get; set; }

        [StringLength(250)]
        public string MetaTitle { get; set; }

        public long? CourseCategoryID { get; set; }

        public virtual CourseCategory CourseCategory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Section> Sections { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User_Study_Course> User_Study_Course { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User_Teacher_Course> User_Teacher_Course { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User> Users { get; set; }
    }
}
