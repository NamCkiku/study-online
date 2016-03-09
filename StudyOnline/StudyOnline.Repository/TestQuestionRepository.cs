using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyOnline.Repository
{
    public class TestQuestionRepository
    {
        private readonly StudyOnline.Entities.Models.StudyOnline _db = null;

        public TestQuestionRepository()
        {
            _db = new Entities.Models.StudyOnline();
        }

      
        public List<StudyOnline.Entities.Models.TestQuestion> ListAllTestQuestion()
        {
            return _db.TestQuestion.ToList();
        }

     
        public StudyOnline.Entities.Models.TestQuestion ViewDetail(long id)
        {
            return _db.TestQuestion.Find(id);
        }

     
        public long CreateTestQuestion(StudyOnline.Entities.Models.TestQuestion tq)
        {
            try
            {
                _db.TestQuestion.Add(tq);
                _db.SaveChanges();
                return tq.ID;
            }
            catch (Exception)
            {
                return -1;
            }
        }

       
        public bool UpdateTestQuestion(StudyOnline.Entities.Models.TestQuestion tq)
        {
            try
            {
                var c = _db.TestQuestion.Find(tq.ID);
                c.Name = tq.Name;
                c.TestAnswer = tq.TestAnswer;
                c.TittleQuestion = tq.TittleQuestion;
                c.Test = tq.Test;
                c.TestID = tq.TestID;
                _db.SaveChanges();
                return true;
            }
            catch (Exception) {
                return false;
            }
        }

       
        public bool DeleteTestQuestion(long id)
        {
            try
            {
                var result = _db.TestQuestion.Find(id);
                _db.TestQuestion.Remove(result);
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
