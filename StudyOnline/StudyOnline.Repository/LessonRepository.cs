using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyOnline.Repository
{
    class LessonRepository
    {
         private readonly StudyOnline.Entities.Models.StudyOnline _db = null;

         public LessonRepository()
        {
            _db = new Entities.Models.StudyOnline();
        }

        // Lấy danh sách bài học
        public List<StudyOnline.Entities.Models.Lesson> ListAllLesson()
        {
            return _db.Lesson.ToList();
        }

        //Lấy thông tin 1 khóa học
        public StudyOnline.Entities.Models.Lesson ViewDetail(long id)
        {
            return _db.Lesson.Find(id);
        }

        //Tạo bài học
        public long CreateLesson(StudyOnline.Entities.Models.Lesson less)
        {
            try
            {
                _db.Lesson.Add(less);
                _db.SaveChanges();
                return less.ID;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        //Cập nhật bài học
        public bool UpdateLesson(StudyOnline.Entities.Models.Lesson less)
        {
            try
            {
                var c = _db.Lesson.Find(less.ID);
                c.LessonName = less.LessonName;
                c.Description = less.Description;
                c.CreateDate = less.CreateDate;
                c.Status = less.Status;
                c.SectionID = less.SectionID;
                _db.SaveChanges();
                return true;
            }
            catch (Exception) {
                return false;
            }
        }

        //Xóa bài học
        public bool DeleteLesson(long id)
        {
            try
            {
                var result = _db.Lesson.Find(id);
                _db.Lesson.Remove(result);
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
