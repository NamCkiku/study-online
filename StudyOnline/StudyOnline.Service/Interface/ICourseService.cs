using StudyOnline.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyOnline.Service
{
    public interface ICourseService
    {

        List<Course> getListCourse();
        long addCourse(Course course);
        bool editCourse(Course course);
        bool deleteCourse(long courseID);
        Course ViewDetail(long id);
    }
}
