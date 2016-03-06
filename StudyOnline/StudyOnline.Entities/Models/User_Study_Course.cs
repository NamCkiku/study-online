namespace StudyOnline.Entities.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User_Study_Course
    {
        public long ID { get; set; }

        public long? UserID { get; set; }

        public long? CourseID { get; set; }

        public bool? Status { get; set; }

        public DateTime? CreateDate { get; set; }

        public virtual Course Course { get; set; }

        public virtual User User { get; set; }
    }
}
