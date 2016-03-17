using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyOnline.Repository
{
    public interface ILessonRepository
    {
        List<StudyOnline.Entities.Models.Lesson> ListAllLesson();
        StudyOnline.Entities.Models.Lesson ViewDetail(long id);
        long CreateLesson(StudyOnline.Entities.Models.Lesson less);
        bool UpdateLesson(StudyOnline.Entities.Models.Lesson less);
        bool DeleteLesson(long id);
    }
}
