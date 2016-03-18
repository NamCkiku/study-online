using StudyOnline.Repository;
using StudyOnline.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyOnline.Service
{
    public class TestQuestionService : ITestQuestionService
    {
        TestQuestionRepository questionRepository = new TestQuestionRepository();
        public List<StudyOnline.Entities.Models.TestQuestion> ListAllTestQuestion()
        {
            return questionRepository.ListAllTestQuestion();
        }
        public StudyOnline.Entities.Models.TestQuestion ViewDetail(long id)
        {
            return questionRepository.ViewDetail(id);
        }
        public long CreateTestQuestion(StudyOnline.Entities.Models.TestQuestion ta)
        {
            return questionRepository.CreateTestQuestion(ta);
        }
        public bool UpdateTestQuestion(StudyOnline.Entities.Models.TestQuestion ta)
        {
            return questionRepository.UpdateTestQuestion(ta);
        }
        public bool DeleteTestQuestion(long id)
        {
            return questionRepository.DeleteTestQuestion(id);
        }
    }
}
