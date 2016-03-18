using StudyOnline.Repository;
using StudyOnline.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyOnline.Service
{
    public class CourseCategoryService: ICourseCategoryService
    {
        CourseCategoryRepository courseCategory = new CourseCategoryRepository();
        public List<StudyOnline.Entities.Models.CourseCategory> ListAllCourseCategory()
        {
            return courseCategory.ListAllCourseCategory();
        }
        public StudyOnline.Entities.Models.CourseCategory ViewDetail(long id)
        {
            return courseCategory.ViewDetail(id);
        }
        public long CreateCourseCategory(StudyOnline.Entities.Models.CourseCategory course)
        {
            return courseCategory.CreateCourseCategory(course);
        }
        public bool UpdateCourseCategory(StudyOnline.Entities.Models.CourseCategory course)
        {
            return courseCategory.UpdateCourseCategory(course);
        }
        public bool DeleteCourseCategory(long id)
        {
            return courseCategory.DeleteCourseCategory(id);
        }
    }
}
