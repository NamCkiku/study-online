using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyOnline.Repository
{
    public class CourseCategoryRepository:ICourseCategoryRepository
    {

        /// <summary>
        /// Lấy danh sách loại khóa học
        /// </summary>
        /// <returns>List</returns>
        public List<StudyOnline.Entities.Models.CourseCategory> ListAllCourseCategory()
        {
            using (StudyOnline.Entities.Models.StudyOnline _db = new StudyOnline.Entities.Models.StudyOnline())
            {
                return _db.CourseCategory.ToList();
            }
        }

        /// <summary>
        /// Xem chi tiết 1 loại khóa học
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>CourseCategory</returns>
        public StudyOnline.Entities.Models.CourseCategory ViewDetail(long id)
        {
            using (StudyOnline.Entities.Models.StudyOnline _db = new StudyOnline.Entities.Models.StudyOnline())
            {
                return _db.CourseCategory.Find(id);
            }
        }

        /// <summary>
        /// Tạo 1 loại khóa học
        /// </summary>
        /// <param name="course">CourseCategory</param>
        /// <returns>long</returns>
        public long CreateCourseCategory(StudyOnline.Entities.Models.CourseCategory course)
        {
            using (StudyOnline.Entities.Models.StudyOnline _db = new StudyOnline.Entities.Models.StudyOnline())
            {
                try
                {
                    _db.CourseCategory.Add(course);
                    _db.SaveChanges();
                    return course.ID;
                }
                catch (Exception)
                {
                    return -1;
                }
            }
        }

        /// <summary>
        /// Cập nhật 1 loại khóa học
        /// </summary>
        /// <param name="course">CourseCategory</param>
        /// <returns>bool</returns>
        public bool UpdateCourseCategory(StudyOnline.Entities.Models.CourseCategory course)
        {
            using (StudyOnline.Entities.Models.StudyOnline _db = new StudyOnline.Entities.Models.StudyOnline())
            {
                try
                {
                    var c = _db.CourseCategory.Find(course.ID);
                    c.Name = course.Name;
                    c.Descrpition = course.Descrpition;
                    c.ParentID = course.ParentID;
                    c.Link = course.Link;
                    c.Tags = course.Tags;
                    c.MetaTittle = course.MetaTittle;
                    c.CreateDate = course.CreateDate;
                    c.Status = course.Status;
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
        /// Xóa 1 khóa học
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>bool</returns>
        public bool DeleteCourseCategory(long id)
        {
            using (StudyOnline.Entities.Models.StudyOnline _db = new StudyOnline.Entities.Models.StudyOnline())
            {
                try
                {
                    var result = _db.CourseCategory.Find(id);
                    _db.CourseCategory.Remove(result);
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
