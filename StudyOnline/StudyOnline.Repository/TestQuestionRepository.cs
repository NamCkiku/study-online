using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyOnline.Repository.Interface;

namespace StudyOnline.Repository
{
    public class TestQuestionRepository:ITestQuestionRepository
    {

        /// <summary>
        /// Lấy danh sách các câu trả lời
        /// </summary>
        /// <returns>List</returns>
        public List<StudyOnline.Entities.Models.TestQuestion> ListAllTestQuestion()
        {
            using (StudyOnline.Entities.Models.StudyOnline _db = new StudyOnline.Entities.Models.StudyOnline())
            {
                return _db.TestQuestion.ToList();
            }
        }

        /// <summary>
        /// Xem chi tiết các câu hỏi
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>TestQuestion</returns>
        public StudyOnline.Entities.Models.TestQuestion ViewDetail(long id)
        {
            using (StudyOnline.Entities.Models.StudyOnline _db = new StudyOnline.Entities.Models.StudyOnline())
            {
                return _db.TestQuestion.Find(id);
            }
        }

        /// <summary>
        /// Thêm câu trả lời
        /// </summary>
        /// <param name="tq">TestQuestion</param>
        /// <returns>long</returns>
        public long CreateTestQuestion(StudyOnline.Entities.Models.TestQuestion tq)
        {
            using (StudyOnline.Entities.Models.StudyOnline _db = new StudyOnline.Entities.Models.StudyOnline())
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
        }

        /// <summary>
        /// Sửa lại câu trả lời
        /// </summary>
        /// <param name="tq">TestQuestion</param>
        /// <returns>bool</returns>
        public bool UpdateTestQuestion(StudyOnline.Entities.Models.TestQuestion tq)
        {
            using (StudyOnline.Entities.Models.StudyOnline _db = new StudyOnline.Entities.Models.StudyOnline())
            {
                try
                {
                    var c = _db.TestQuestion.Find(tq.ID);
                    c.Name = tq.Name;
                    //c.TestAnswer = tq.TestAnswer;
                    c.TittleQuestion = tq.TittleQuestion;
                    c.Test = tq.Test;
                    c.TestID = tq.TestID;
                    _db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }


        /// <summary>
        /// Xóa câu trả lời
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>bool</returns>
        public bool DeleteTestQuestion(long id)
        {
            using (StudyOnline.Entities.Models.StudyOnline _db = new StudyOnline.Entities.Models.StudyOnline())
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
}
