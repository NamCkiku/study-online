using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyOnline.Repository
{
    public class TestAnswerRepository:ITestAnswerRepository
    {
        /// <summary>
        /// Lấy danh sách các câu hỏi
        /// </summary>
        /// <returns>List</returns>
        public List<StudyOnline.Entities.Models.TestAnswer> ListAllTestAnswer()
        {
            using (StudyOnline.Entities.Models.StudyOnline _db = new StudyOnline.Entities.Models.StudyOnline())
            {
                return _db.TestAnswer.ToList();
            }
        }

        /// <summary>
        /// Lấy chi tiết 1 câu hỏi
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>TestAnswer</returns>
        public StudyOnline.Entities.Models.TestAnswer ViewDetail(long id)
        {
            using (StudyOnline.Entities.Models.StudyOnline _db = new StudyOnline.Entities.Models.StudyOnline())
            {
                return _db.TestAnswer.Find(id);
            }
        }

        /// <summary>
        /// Tạo câu hỏi
        /// </summary>
        /// <param name="ta">TestAnswer</param>
        /// <returns>long</returns>
        public long CreateTestAnswer(StudyOnline.Entities.Models.TestAnswer ta)
        {
            using (StudyOnline.Entities.Models.StudyOnline _db = new StudyOnline.Entities.Models.StudyOnline())
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
        }

        /// <summary>
        /// Cập nhật câu hỏi
        /// </summary>
        /// <param name="ta">TestAnswer</param>
        /// <returns>bool</returns>
        public bool UpdateTestAnswer(StudyOnline.Entities.Models.TestAnswer ta)
        {
            using (StudyOnline.Entities.Models.StudyOnline _db = new StudyOnline.Entities.Models.StudyOnline())
            {
                try
                {
                    var c = _db.TestAnswer.Find(ta.ID);
                    c.Name = ta.Name;
                    //c.TestQuestion = ta.TestQuestion;
                    c.TittleAnswer = ta.TittleAnswer;
                    c.TestQuestionID = ta.TestQuestionID;
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
        /// Xóa câu hỏi
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>bool</returns>
        public bool DeleteTestAnswer(long id)
        {
            using (StudyOnline.Entities.Models.StudyOnline _db = new StudyOnline.Entities.Models.StudyOnline())
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
}
