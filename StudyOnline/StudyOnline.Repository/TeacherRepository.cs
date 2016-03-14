using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyOnline.Entities.Models;

namespace StudyOnline.Repository
{
    public class TeacherRepository
    {
        /// <summary>
        /// Lấy danh sách khóa học của giáo viên
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Tuple<User,Course>> GetListByTearcherId(long id)
        {
            using(StudyOnline.Entities.Models.StudyOnline _db=new Entities.Models.StudyOnline())
            {
                List<Tuple<User, Course>> list = new List<Tuple<User, Course>>();
                var result = (from a in _db.User
                              join b in _db.User_Teacher_Course on a.ID equals b.UserID
                              join c in _db.Course on b.CourseID equals c.ID
                              select new
                              {
                                  a,
                                  c
                              }
                ).ToList();
                foreach(var item in result)
                {
                    list.Add(new Tuple<User, Course>(item.a, item.c));
                    
                }
                return list;
            }
        }

        /// <summary>
        /// Giáo viên tạo khóa học
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cs"></param>
        /// <returns></returns>
        public long CreateCouseByTeacherId(long id, Course cs)
        {
            using (StudyOnline.Entities.Models.StudyOnline _db = new Entities.Models.StudyOnline())
            { 
                try
                {
                    _db.Course.Add(cs);
                    _db.SaveChanges();
                    return cs.ID;
                }
                catch(Exception)
                {
                    return -1;
                }
            }
        }


    }
}
