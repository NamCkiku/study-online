using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyOnline.Entities.Models;

namespace StudyOnline.Repository
{
    public class CourseRepository
    {
        private readonly StudyOnline.Entities.Models.StudyOnline _db = null;

        public CourseRepository()
        {
            _db = new Entities.Models.StudyOnline();
        }

        // Lấy danh sách khóa học
        public List<StudyOnline.Entities.Models.Course> ListAllCourse()
        {
            return _db.Course.ToList();
        }

        //Lấy thông tin 1 khóa học
        public StudyOnline.Entities.Models.Course ViewDetail(long id)
        {
            return _db.Course.Find(id);
        }

        //Tạo khóa học
        public long CreateCourse(StudyOnline.Entities.Models.Course course)
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

        //Cập nhật khóa học
        /// <summary>
        /// Cập Nhập Khóa Học
        /// </summary>
        /// <param name="course">Khóa Học</param>
        /// <returns></returns>
        public bool UpdateCourse(StudyOnline.Entities.Models.Course course)
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
            catch (Exception) {
                return false;
            }
        }

        //Xóa khóa học
        public bool DeleteCourse(long id)
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
