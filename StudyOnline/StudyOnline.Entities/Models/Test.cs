namespace StudyOnline.Entities.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Test")]
    public partial class Test
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Test()
        {
            TestQuestion = new HashSet<TestQuestion>();
        }

        public long ID { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        public int? TimeTest { get; set; }

        public long? SectionID { get; set; }

        public int? Point { get; set; }

        public int? Rank { get; set; }

        public virtual Section Section { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TestQuestion> TestQuestion { get; set; }
    }
}
