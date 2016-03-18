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
    public class TeacherService : ITeacherService
    {
        TeacherRepository teacherRepository = new TeacherRepository();
        public List<Tuple<User, Course>> GetListByTearcherId(long id)
        {
            return teacherRepository.GetListByTearcherId(id);
        }
        public long CreateCouseByTeacherId(long id, Course cs)
        {
            return teacherRepository.CreateCouseByTeacherId(id, cs);
        }
    }
}
