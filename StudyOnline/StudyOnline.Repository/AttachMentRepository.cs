using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyOnline.Repository
{
    public class AttachMentRepository
    {
        private readonly StudyOnline.Entities.Models.StudyOnline _db = null;

        public AttachMentRepository()
        {
            _db = new Entities.Models.StudyOnline();
        }

        //Lấy danh sách tài liệu
        public List<StudyOnline.Entities.Models.AttachMent> ListAllAttachMent()
        {
            return _db.AttachMent.ToList();
        }

        // Lấy 1 đối tượng
        public StudyOnline.Entities.Models.AttachMent ViewDetail(long id)
        {
            return _db.AttachMent.Find(id);
        }
        // Thêm tài liệu
        public long InsertAttachMent(StudyOnline.Entities.Models.AttachMent am)
        {
            try
            {
                _db.AttachMent.Add(am);
                _db.SaveChanges();
                return am.ID;
            }
            catch(Exception)
            {
                return -1;
            }
        }

        //Sửa tài liệu
        public bool UpdateAttachMent(StudyOnline.Entities.Models.AttachMent am)
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
            catch(Exception)
            {
                return false;
            }
        }

        //Xóa tài liệu
        public bool DeleteAttachMent(long id)
        {
            try {
                var a = _db.AttachMent.Find(id);
                _db.AttachMent.Remove(a);
                _db.SaveChanges();
                return true;
            }
            catch (Exception) {
                return false;
            }
        }
    }
}
