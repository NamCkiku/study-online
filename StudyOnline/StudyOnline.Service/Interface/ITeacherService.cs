using StudyOnline.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyOnline.Service.Interface
{
    public interface ITeacherService
    {
        List<Tuple<User, Course>> GetListByTearcherId(long id);
        long CreateCouseByTeacherId(long id, Course cs);
    }
}
