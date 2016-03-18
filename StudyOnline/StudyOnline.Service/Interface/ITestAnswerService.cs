using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyOnline.Service.Interface
{
    public interface ITestAnswerService
    {
        List<StudyOnline.Entities.Models.TestAnswer> ListAllTestAnswer();
        StudyOnline.Entities.Models.TestAnswer ViewDetail(long id);
        long CreateTestAnswer(StudyOnline.Entities.Models.TestAnswer ta);
        bool UpdateTestAnswer(StudyOnline.Entities.Models.TestAnswer ta);
        bool DeleteTestAnswer(long id);
    }
}
