using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyOnline.Repository
{
    public class TestAnswerRepository
    {
         private readonly StudyOnline.Entities.Models.StudyOnline _db = null;

         public TestAnswerRepository()
        {
            _db = new Entities.Models.StudyOnline();
        }

      
        public List<StudyOnline.Entities.Models.TestAnswer> ListAllTestAnswer()
        {
            return _db.TestAnswer.ToList();
        }

     
        public StudyOnline.Entities.Models.TestAnswer ViewDetail(long id)
        {
            return _db.TestAnswer.Find(id);
        }

     
        public long CreateTestAnswer(StudyOnline.Entities.Models.TestAnswer ta)
        {
            try
            {
                _db.TestAnswer.Add(ta);
                _db.SaveChanges();
                return ta.ID;
            }
            catch (Exception)
            {
                return -1;
            }
        }

       
        public bool UpdateTestAnswer(StudyOnline.Entities.Models.TestAnswer ta)
        {
            try
            {
                var c = _db.TestAnswer.Find(ta.ID);
                c.Name = ta.Name;
                c.TestQuestion = ta.TestQuestion;
                c.TittleAnswer = ta.TittleAnswer;
                c.TestQuestionID = ta.TestQuestionID;
                _db.SaveChanges();
                return true;
            }
            catch (Exception) {
                return false;
            }
        }

       
        public bool DeleteTestAnswer(long id)
        {
            try
            {
                var result = _db.TestAnswer.Find(id);
                _db.TestAnswer.Remove(result);
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
