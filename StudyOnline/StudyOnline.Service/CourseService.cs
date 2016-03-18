using StudyOnline.Entities.Models;
using StudyOnline.Repository;
using StudyOnline.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyOnline.Service
{
    public class CourseService : ICourseService
    {
        CourseRepository rpCourse = new CourseRepository();
        public List<Course> getListCourse()
        {
            return rpCourse.getListCourse();
        }
        public long addCourse(Course course)
        {
            return rpCourse.addCourse(course);
        }
        public bool editCourse(Course course)
        {
            return rpCourse.editCourse(course);
        }
        public bool deleteCourse(long courseID)
        {
            return rpCourse.deleteCourse(courseID);
        }
        public Course ViewDetail(long id)
        {
            return rpCourse.ViewDetail(id);
        }
    }
}
