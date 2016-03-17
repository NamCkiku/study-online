using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyOnline.Repository
{
    public class VideoRepository
    {
        /// <summary>
        /// Danh sách Video
        /// </summary>
        /// <returns>List</returns>
        public List<StudyOnline.Entities.Models.Video> ListAllVideo()
        {
            using (StudyOnline.Entities.Models.StudyOnline _db = new StudyOnline.Entities.Models.StudyOnline())
            {
                return _db.Video.ToList();
            }

        }

        /// <summary>
        /// Xem chi tiết 1 video
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>Video</returns>
        public StudyOnline.Entities.Models.Video ViewDetail(long id)
        {
            using (StudyOnline.Entities.Models.StudyOnline _db = new StudyOnline.Entities.Models.StudyOnline())
            {
                return _db.Video.Find(id);
            }
        }

        /// <summary>
        /// Thêm video
        /// </summary>
        /// <param name="tq">Video</param>
        /// <returns>long</returns>
        public long InsertVideo(StudyOnline.Entities.Models.Video tq)
        {
            using (StudyOnline.Entities.Models.StudyOnline _db = new StudyOnline.Entities.Models.StudyOnline())
            {
                try
                {
                    _db.Video.Add(tq);
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
        /// Cập nhật video
        /// </summary>
        /// <param name="v">Video</param>
        /// <returns>bool</returns>
        public bool UpdateVideo(StudyOnline.Entities.Models.Video v)
        {
            using (StudyOnline.Entities.Models.StudyOnline _db = new StudyOnline.Entities.Models.StudyOnline())
            {
                try
                {
                    var c = _db.Video.Find(v.ID);
                    c.Name = v.Name;
                    c.Link = v.Link;
                    c.Length = v.Length;
                    c.CreateDate = v.CreateDate;
                    c.Description = v.Description;
                    c.Status = v.Status;
                    c.LessonID = v.LessonID;

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
        /// Xóa Video
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>bool</returns>
        public bool DeleteVideo(long id)
        {
            using (StudyOnline.Entities.Models.StudyOnline _db = new StudyOnline.Entities.Models.StudyOnline())
            {
                try
                {
                    var result = _db.Video.Find(id);
                    _db.Video.Remove(result);
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
