namespace StudyOnline.Entities.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GroupUser")]
    public partial class GroupUser
    {
        public long ID { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        public long? UserID { get; set; }

        public int? RolesID { get; set; }

        public virtual User User { get; set; }
    }
}
