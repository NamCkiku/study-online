using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyOnline.Service.Interface
{
    public interface ILessonService
    {
        List<StudyOnline.Entities.Models.Lesson> ListAllLesson();
        StudyOnline.Entities.Models.Lesson ViewDetail(long id);
        long CreateLesson(StudyOnline.Entities.Models.Lesson less);
        bool UpdateLesson(StudyOnline.Entities.Models.Lesson less);
        bool DeleteLesson(long id);
    }
}
