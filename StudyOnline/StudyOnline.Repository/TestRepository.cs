using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyOnline.Repository
{
    public class TestRepository
    {
        private readonly StudyOnline.Entities.Models.StudyOnline _db = null;

        public TestRepository()
        {
            _db = new Entities.Models.StudyOnline();
        }

        // Lấy danh sách bài học
        public List<StudyOnline.Entities.Models.Test> ListAllTest()
        {
            return _db.Test.ToList();
        }

        //Lấy thông tin 1 khóa học
        public StudyOnline.Entities.Models.Test ViewDetail(long id)
        {
            return _db.Test.Find(id);
        }

        //Tạo bài học
        public long CreateTest(StudyOnline.Entities.Models.Test tes)
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

        //Cập nhật bài học
        public bool UpdateTest(StudyOnline.Entities.Models.Test tes)
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
            catch (Exception) {
                return false;
            }
        }

        //Xóa bài học
        public bool DeleteTest(long id)
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
