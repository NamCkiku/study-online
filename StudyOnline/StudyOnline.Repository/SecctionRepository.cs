using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyOnline.Repository
{
    public class SecctionRepository
    {
         private readonly StudyOnline.Entities.Models.StudyOnline _db = null;

         public SecctionRepository()
        {
            _db = new Entities.Models.StudyOnline();
        }

        // Lấy danh sách bài học
        public List<StudyOnline.Entities.Models.Section> ListAllSection()
        {
            return _db.Section.ToList();
        }

        //Lấy thông tin 1 khóa học
        public StudyOnline.Entities.Models.Section ViewDetail(long id)
        {
            return _db.Section.Find(id);
        }

        //Tạo bài học
        public long CreateSection(StudyOnline.Entities.Models.Section sec)
        {
            try
            {
                _db.Section.Add(sec);
                _db.SaveChanges();
                return sec.ID;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        //Cập nhật bài học
        public bool UpdateSection(StudyOnline.Entities.Models.Section sec)
        {
            try
            {
                var c = _db.Section.Find(sec.ID);
                c.SectionName = sec.SectionName;
                c.Title = sec.Title;
                c.Description = sec.Description;
                c.CreateDate = sec.CreateDate;
                c.Status = sec.Status;
                c.CourseID = sec.CourseID;
                _db.SaveChanges();
                return true;
            }
            catch (Exception) {
                return false;
            }
        }

        //Xóa bài học
        public bool DeleteSection(long id)
        {
            try
            {
                var result = _db.Section.Find(id);
                _db.Section.Remove(result);
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
