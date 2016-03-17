using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyOnline.Entities.Models;

namespace StudyOnline.Repository
{
    public class CourseRepository : ICourseRepository
    {

        /// <summary>
        /// Lấy danh sách khóa học
        /// </summary>
        /// <returns>List</returns>
        public List<StudyOnline.Entities.Models.Course> getListCourse()
        {
            using (StudyOnline.Entities.Models.StudyOnline _db = new StudyOnline.Entities.Models.StudyOnline())
            {
                return _db.Course.ToList();
            }
        }

        /// <summary>
        /// Xem chi tiết 1 khóa học
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>Course</returns>
        public StudyOnline.Entities.Models.Course ViewDetail(long id)
        {
            using (StudyOnline.Entities.Models.StudyOnline _db = new StudyOnline.Entities.Models.StudyOnline())
            {
                return _db.Course.Find(id);
            }
        }

        /// <summary>
        /// Tạo 1 khóa học
        /// </summary>
        /// <param name="course">Course</param>
        /// <returns>long</returns>
        public long addCourse(StudyOnline.Entities.Models.Course course)
        {
            using (StudyOnline.Entities.Models.StudyOnline _db = new StudyOnline.Entities.Models.StudyOnline())
            {
                try
                {
                    _db.Course.Add(course);
                    _db.SaveChanges();
                    return course.ID;
                }
                catch (Exception)
                {
                    return -1;
                }
            }
        }

        //Cập nhật khóa học
        /// <summary>
        /// Cập Nhật Khóa Học
        /// </summary>
        /// <param name="course">Course</param>
        /// <returns>bool</returns>
        public bool editCourse(StudyOnline.Entities.Models.Course course)
        {
            using (StudyOnline.Entities.Models.StudyOnline _db = new StudyOnline.Entities.Models.StudyOnline())
            {
                try
                {
                    var c = _db.Course.Find(course.ID);
                    c.CourseName = course.CourseName;
                    c.Avatar = course.Avatar;
                    c.VideoIntroduce = course.VideoIntroduce;
                    c.Description = course.Description;
                    c.Content = course.Content;
                    c.PriceSale = course.PriceSale;
                    c.Price = course.Price;
                    c.ViewCount = course.ViewCount;
                    c.CreateDate = course.CreateDate;
                    c.Tags = course.Tags;
                    c.Status = course.Status;
                    c.TopHot = course.TopHot;
                    c.MetaTitle = course.MetaTitle;
                    c.CourseCategoryID = course.CourseCategoryID;
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
        public bool deleteCourse(long id)
        {
            using (StudyOnline.Entities.Models.StudyOnline _db = new StudyOnline.Entities.Models.StudyOnline())
            {
                try
                {
                    var result = _db.Course.Find(id);
                    _db.Course.Remove(result);
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
