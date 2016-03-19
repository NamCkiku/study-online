using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyOnline.Repository.Interface
{
    public interface ITestQuestionRepository
    {
        List<StudyOnline.Entities.Models.TestQuestion> ListAllTestQuestion();
        StudyOnline.Entities.Models.TestQuestion ViewDetail(long id);
        long CreateTestQuestion(StudyOnline.Entities.Models.TestQuestion tq);
        bool UpdateTestQuestion(StudyOnline.Entities.Models.TestQuestion tq);
        bool DeleteTestQuestion(long id);
    }
}
