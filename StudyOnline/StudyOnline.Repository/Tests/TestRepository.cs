using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyOnline.Repository.Interface;

namespace StudyOnline.Repository
{
    public class TestRepository:ITestRepository
    {
        /// <summary>
        /// Lấy danh sách bài kiểm tra
        /// </summary>
        /// <returns>List</returns>
        public List<StudyOnline.Entities.Models.Test> ListAllTest()
        {
            using (StudyOnline.Entities.Models.StudyOnline _db = new StudyOnline.Entities.Models.StudyOnline())
            {
                return _db.Test.ToList();
            }
        }

        /// <summary>
        /// Xem chi tiết 1 bài kiểm tra
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>Test</returns>
        public StudyOnline.Entities.Models.Test ViewDetail(long id)
        {
            using (StudyOnline.Entities.Models.StudyOnline _db = new StudyOnline.Entities.Models.StudyOnline())
            {
                return _db.Test.Find(id);
            }
        }

        /// <summary>
        /// Tạo bài kiểm tra
        /// </summary>
        /// <param name="tes">Test</param>
        /// <returns>long</returns>
        public long CreateTest(StudyOnline.Entities.Models.Test tes)
        {
            using (StudyOnline.Entities.Models.StudyOnline _db = new StudyOnline.Entities.Models.StudyOnline())
            {
                try
                {
                    _db.Test.Add(tes);
                    _db.SaveChanges();
                    return tes.ID;
                }
                catch (Exception)
                {
                    return -1;
                }
            }
        }

        /// <summary>
        /// Cập nhật bài kiểm tra
        /// </summary>
        /// <param name="tes">Test</param>
        /// <returns>bool</returns>
        public bool UpdateTest(StudyOnline.Entities.Models.Test tes)
        {
            using (StudyOnline.Entities.Models.StudyOnline _db = new StudyOnline.Entities.Models.StudyOnline())
            {
                try
                {
                    var c = _db.Test.Find(tes.ID);
                    c.Name = tes.Name;
                    c.TimeTest = tes.TimeTest;
                    c.SectionID = tes.SectionID;
                    c.Point = tes.Point;
                    c.Rank = tes.Rank;
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
        /// Xóa bài kiểm tra
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>bool</returns>
        public bool DeleteTest(long id)
        {
            using (StudyOnline.Entities.Models.StudyOnline _db = new StudyOnline.Entities.Models.StudyOnline())
            {
                try
                {
                    var result = _db.Test.Find(id);
                    _db.Test.Remove(result);
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
