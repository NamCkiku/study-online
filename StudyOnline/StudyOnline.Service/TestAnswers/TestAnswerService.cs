using StudyOnline.Repository;
using StudyOnline.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyOnline.Service
{
    public class TestAnswerService : ITestAnswerService
    {
        TestAnswerRepository answerRepository = new TestAnswerRepository();
        public List<StudyOnline.Entities.Models.TestAnswer> ListAllTestAnswer()
        {
            return answerRepository.ListAllTestAnswer();
        }
        public StudyOnline.Entities.Models.TestAnswer ViewDetail(long id)
        {
            return answerRepository.ViewDetail(id);
        }
        public long CreateTestAnswer(StudyOnline.Entities.Models.TestAnswer ta)
        {
            return answerRepository.CreateTestAnswer(ta);
        }
        public bool UpdateTestAnswer(StudyOnline.Entities.Models.TestAnswer ta)
        {
            return answerRepository.UpdateTestAnswer(ta);
        }
        public bool DeleteTestAnswer(long id)
        {
            return answerRepository.DeleteTestAnswer(id);
        }
    }
}
