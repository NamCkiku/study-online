namespace StudyOnline.Entities.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class StudyOnline : DbContext
    {
        public StudyOnline()
            : base("name=StudyOnline")
        {
        }

        public virtual DbSet<AttachMent> AttachMent { get; set; }
        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<CourseCategory> CourseCategory { get; set; }
        public virtual DbSet<FriendUser> FriendUser { get; set; }
        public virtual DbSet<GroupUser> GroupUser { get; set; }
        public virtual DbSet<Lesson> Lesson { get; set; }
        public virtual DbSet<PayMent> PayMent { get; set; }
        public virtual DbSet<Section> Section { get; set; }
        public virtual DbSet<Test> Test { get; set; }
        public virtual DbSet<TestAnswer> TestAnswer { get; set; }
        public virtual DbSet<TestQuestion> TestQuestion { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<User_Study_Course> User_Study_Course { get; set; }
        public virtual DbSet<User_Teacher_Course> User_Teacher_Course { get; set; }
        public virtual DbSet<Video> Video { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
                .HasMany(e => e.User_Teacher_Course)
                .WithRequired(e => e.Course)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Course>()
                .HasMany(e => e.User)
                .WithMany(e => e.Course)
                .Map(m => m.ToTable("User_Course").MapLeftKey("CourseID").MapRightKey("UserID"));

            modelBuilder.Entity<GroupUser>()
                .HasOptional(e => e.User)
                .WithRequired(e => e.GroupUser);

            modelBuilder.Entity<User>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.GroupID)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.FriendUser)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.User_Teacher_Course)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User_Study_Course>()
                .HasOptional(e => e.User)
                .WithRequired(e => e.User_Study_Course);
        }
    }
}
