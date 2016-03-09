using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyOnline.Repository
{
    public class CourseCategoryRepository
    {
         private readonly StudyOnline.Entities.Models.StudyOnline _db = null;

         public CourseCategoryRepository()
        {
            _db = new Entities.Models.StudyOnline();
        }


         // Lấy danh sách loại khóa học
         public List<StudyOnline.Entities.Models.CourseCategory> ListAllCourseCategory()
         {
             return _db.CourseCategory.ToList();
         }

         //Lấy thông tin 1 khóa học
         public StudyOnline.Entities.Models.CourseCategory ViewDetail(long id)
         {
             return _db.CourseCategory.Find(id);
         }

         //Tạo khóa học
         public long CreateCourseCategory(StudyOnline.Entities.Models.CourseCategory course)
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

         //Cập nhật loại khóa học
         public bool UpdateCourseCategory(StudyOnline.Entities.Models.CourseCategory course)
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

         //Xóa khóa học
         public bool DeleteCourseCategory(long id)
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
