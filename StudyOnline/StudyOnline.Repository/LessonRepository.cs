using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyOnline.Repository
{
    class LessonRepository
    {
        /// <summary>
        /// Lấy danh sách các bài học
        /// </summary>
        /// <returns>List</returns>
        public List<StudyOnline.Entities.Models.Lesson> ListAllLesson()
        {
            using (StudyOnline.Entities.Models.StudyOnline _db = new StudyOnline.Entities.Models.StudyOnline())
            {
                return _db.Lesson.ToList();
            }
        }

        /// <summary>
        /// Xem chi tiết 1 bài học
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>Lesson</returns>
        public StudyOnline.Entities.Models.Lesson ViewDetail(long id)
        {
            using (StudyOnline.Entities.Models.StudyOnline _db = new StudyOnline.Entities.Models.StudyOnline())
            {
                return _db.Lesson.Find(id);
            }
        }

        /// <summary>
        /// Tạo 1 bài học
        /// </summary>
        /// <param name="less">Lesson</param>
        /// <returns>long</returns>
        public long CreateLesson(StudyOnline.Entities.Models.Lesson less)
        {
            using (StudyOnline.Entities.Models.StudyOnline _db = new StudyOnline.Entities.Models.StudyOnline())
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
        }

        /// <summary>
        /// Cập nhật 1 khóa học
        /// </summary>
        /// <param name="less">Lesson</param>
        /// <returns>bool</returns>
        public bool UpdateLesson(StudyOnline.Entities.Models.Lesson less)
        {
            using (StudyOnline.Entities.Models.StudyOnline _db = new StudyOnline.Entities.Models.StudyOnline())
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
                catch (Exception)
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Xóa 1 bài học
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>bool</returns>
        public bool DeleteLesson(long id)
        {
            using (StudyOnline.Entities.Models.StudyOnline _db = new StudyOnline.Entities.Models.StudyOnline())
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
}
