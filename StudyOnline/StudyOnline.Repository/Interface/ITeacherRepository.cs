using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyOnline.Entities.Models;

namespace StudyOnline.Repository.Interface
{
    public interface ITeacherRepository
    {
        List<Tuple<User, Course>> GetListByTearcherId(long id);
        long CreateCouseByTeacherId(long id, Course cs);
    }
}
