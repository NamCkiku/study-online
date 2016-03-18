using StudyOnline.Repository;
using StudyOnline.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyOnline.Service
{
    public class LessonService : ILessonService
    {
        LessonRepository lsrepository = new LessonRepository();
        public List<StudyOnline.Entities.Models.Lesson> ListAllLesson()
        {
            return lsrepository.ListAllLesson();
        }
        public StudyOnline.Entities.Models.Lesson ViewDetail(long id)
        {
            return lsrepository.ViewDetail(id);
        }
        public long CreateLesson(StudyOnline.Entities.Models.Lesson less)
        {
            return lsrepository.CreateLesson(less);
        }
        public bool UpdateLesson(StudyOnline.Entities.Models.Lesson less)
        {
            return lsrepository.UpdateLesson(less);
        }
        public bool DeleteLesson(long id)
        {
            return lsrepository.DeleteLesson(id);
        }
    }
}
