using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyOnline.Repository
{
    public class SecctionRepository
    {
        /// <summary>
        /// Lấy danh sách phần học
        /// </summary>
        /// <returns>List</returns>
        public List<StudyOnline.Entities.Models.Section> ListAllSection()
        {
            using (StudyOnline.Entities.Models.StudyOnline _db = new StudyOnline.Entities.Models.StudyOnline())
            {
                return _db.Section.ToList();
            }
        }

        /// <summary>
        /// Lấy thông tin chi tiết 1 phần học
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>Section</returns>
        public StudyOnline.Entities.Models.Section ViewDetail(long id)
        {
            using (StudyOnline.Entities.Models.StudyOnline _db = new StudyOnline.Entities.Models.StudyOnline())
            {
                return _db.Section.Find(id);
            }
        }

        /// <summary>
        /// Tạo 1 phân học
        /// </summary>
        /// <param name="sec">Section</param>
        /// <returns>long</returns>
        public long CreateSection(StudyOnline.Entities.Models.Section sec)
        {
            using (StudyOnline.Entities.Models.StudyOnline _db = new StudyOnline.Entities.Models.StudyOnline())
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
        }

        /// <summary>
        /// Cập nhập phân học
        /// </summary>
        /// <param name="sec">Section</param>
        /// <returns>bool</returns>
        public bool UpdateSection(StudyOnline.Entities.Models.Section sec)
        {
            using (StudyOnline.Entities.Models.StudyOnline _db = new StudyOnline.Entities.Models.StudyOnline())
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
                catch (Exception)
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Xóa phần học
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>bool</returns>
        public bool DeleteSection(long id)
        {
            using (StudyOnline.Entities.Models.StudyOnline _db = new StudyOnline.Entities.Models.StudyOnline())
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
}
