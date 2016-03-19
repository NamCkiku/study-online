using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyOnline.Repository.Interface
{
    public interface ICourseCategoryRepository
    {
        List<StudyOnline.Entities.Models.CourseCategory> ListAllCourseCategory();
        StudyOnline.Entities.Models.CourseCategory ViewDetail(long id);
        long CreateCourseCategory(StudyOnline.Entities.Models.CourseCategory course);
        bool UpdateCourseCategory(StudyOnline.Entities.Models.CourseCategory course);
        bool DeleteCourseCategory(long id);
    }
}
