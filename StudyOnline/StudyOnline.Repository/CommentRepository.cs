using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyOnline.Repository
{
    public class CommentRepository
    {
        private readonly StudyOnline.Entities.Models.StudyOnline _db = null;

        public CommentRepository()
        {
            _db = new Entities.Models.StudyOnline();
        }

        //Lấy danh sách Comment
        public List<StudyOnline.Entities.Models.Comment> ListAllComment()
        {
            return _db.Comment.ToList();
        }

        //Lấy 1 đối tượng comment
        public StudyOnline.Entities.Models.Comment ViewDetail(long id)
        {
            return _db.Comment.Find(id);
        }

        //Thêm comment
        public long InsertComment(StudyOnline.Entities.Models.Comment com)
        {
            try {
                _db.Comment.Add(com);
                _db.SaveChanges();
                return com.ID;
            }
            catch (Exception) {
                return -1;
            }
        }

        //Sửa comment
        public bool UpdateComment(StudyOnline.Entities.Models.Comment com)
        {
            try
            {
                var co = _db.Comment.Find(com.ID);
                co.UserName = com.UserName;
                co.Content = com.Content;
                co.CreateDate = com.CreateDate;
                co.Avatar = com.Avatar;
                co.Status = com.Status;
                co.UserID = com.UserID;
                co.LessonID = com.LessonID;
                co.ParentID = com.ParentID;
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //Xóa comment
        public bool DeleteComment(long id)
        {
            try
            {

                var com = _db.Comment.Find(id);
                _db.Comment.Remove(com);
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
