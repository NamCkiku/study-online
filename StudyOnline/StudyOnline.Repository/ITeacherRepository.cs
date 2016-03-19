using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyOnline.Entities.Models;

namespace StudyOnline.Repository
{
    public interface ITeacherRepository
    {
        List<Tuple<User, Course>> GetListByTearcherId(long id);
        List<Tuple<User, Course>> GetListByCourseCategory(long id);
        List<Tuple<User, Course>> GetListByViewCount();
        List<Tuple<User, Course, CourseCategory>> GetListByCourseCategoryShow();
        long CreateCouseByTeacherId(long id, Course cs);
    }
}
