namespace StudyOnline.Entities.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TestQuestion")]
    public partial class TestQuestion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TestQuestion()
        {
            TestAnswer = new HashSet<TestAnswer>();
        }

        public long ID { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [Column(TypeName = "ntext")]
        public string TittleQuestion { get; set; }

        public long? TestID { get; set; }

        public virtual Test Test { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TestAnswer> TestAnswer { get; set; }
    }
}
