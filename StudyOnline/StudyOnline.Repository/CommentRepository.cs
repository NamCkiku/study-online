using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyOnline.Repository
{
    public class CommentRepository:ICommentRepository
    {
        /// <summary>
        /// Lấy danh sách comment
        /// </summary>
        /// <returns>List</returns>
        public List<StudyOnline.Entities.Models.Comment> ListAllComment()
        {
            using (StudyOnline.Entities.Models.StudyOnline _db = new StudyOnline.Entities.Models.StudyOnline())
            {
                return _db.Comment.ToList();
            }
        }

        /// <summary>
        /// Xem chi tiết 1 đối tượng
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>Comment</returns>
        public StudyOnline.Entities.Models.Comment ViewDetail(long id)
        {
            using (StudyOnline.Entities.Models.StudyOnline _db = new StudyOnline.Entities.Models.StudyOnline())
            {
                return _db.Comment.Find(id);
            }
        }

        /// <summary>
        /// Thêm comment
        /// </summary>
        /// <param name="com">Comment</param>
        /// <returns>long</returns>
        public long InsertComment(StudyOnline.Entities.Models.Comment com)
        {
            using (StudyOnline.Entities.Models.StudyOnline _db = new StudyOnline.Entities.Models.StudyOnline())
            {
                try
                {
                    _db.Comment.Add(com);
                    _db.SaveChanges();
                    return com.ID;
                }
                catch (Exception)
                {
                    return -1;
                }
            }
        }

        /// <summary>
        /// Sửa comment
        /// </summary>
        /// <param name="com">Comment</param>
        /// <returns>bool</returns>
        public bool UpdateComment(StudyOnline.Entities.Models.Comment com)
        {
            using (StudyOnline.Entities.Models.StudyOnline _db = new StudyOnline.Entities.Models.StudyOnline())
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
        }

        /// <summary>
        /// Xóa comment
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>bool</returns>
        public bool DeleteComment(long id)
        {
            using (StudyOnline.Entities.Models.StudyOnline _db = new StudyOnline.Entities.Models.StudyOnline())
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
}
