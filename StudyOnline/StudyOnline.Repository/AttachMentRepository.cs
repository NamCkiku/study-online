using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyOnline.Repository.Interface;

namespace StudyOnline.Repository
{
    public class AttachMentRepository:IAttachMentRepository
    {
        /// <summary>
        /// Lấy danh sách tài liệu
        /// </summary>
        /// <returns></returns>
        public List<StudyOnline.Entities.Models.AttachMent> ListAllAttachMent()
        {
            using (StudyOnline.Entities.Models.StudyOnline _db = new StudyOnline.Entities.Models.StudyOnline())
            {
                return _db.AttachMent.ToList();
            }
        }

        /// <summary>
        /// Xem chi tiết 1 đối tượng
        /// </summary>
        /// <param name="id">Mã</param>
        /// <returns>AttachMent</returns>
        public StudyOnline.Entities.Models.AttachMent ViewDetail(long id)
        {
            using (StudyOnline.Entities.Models.StudyOnline _db = new StudyOnline.Entities.Models.StudyOnline())
            {
                return _db.AttachMent.Find(id);
            }
        }
        /// <summary>
        /// Thêm tài liệu
        /// </summary>
        /// <param name="am">AttachMent</param>
        /// <returns>long</returns>
        public long InsertAttachMent(StudyOnline.Entities.Models.AttachMent am)
        {
            using (StudyOnline.Entities.Models.StudyOnline _db = new StudyOnline.Entities.Models.StudyOnline())
            {
                try
                {
                    _db.AttachMent.Add(am);
                    _db.SaveChanges();
                    return am.ID;
                }
                catch (Exception)
                {
                    return -1;
                }
            }
        }

        /// <summary>
        /// Sửa tài liệu
        /// </summary>
        /// <param name="am">AttachMent</param>
        /// <returns>bool</returns>
        public bool UpdateAttachMent(StudyOnline.Entities.Models.AttachMent am)
        {
            using (StudyOnline.Entities.Models.StudyOnline _db = new StudyOnline.Entities.Models.StudyOnline())
            {
                try
                {
                    var a = _db.AttachMent.Find(am.ID);
                    a.FileName = am.FileName;
                    a.Path = am.Path;
                    a.Type = am.Type;
                    a.CreateDate = am.CreateDate;
                    a.Status = am.Status;
                    a.LessonID = am.LessonID;
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
        /// Xóa tài liệu
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>bool</returns>
        public bool DeleteAttachMent(long id)
        {
            using (StudyOnline.Entities.Models.StudyOnline _db = new StudyOnline.Entities.Models.StudyOnline())
            {
                try
                {
                    var a = _db.AttachMent.Find(id);
                    _db.AttachMent.Remove(a);
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
