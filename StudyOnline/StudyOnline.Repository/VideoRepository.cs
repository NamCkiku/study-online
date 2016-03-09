using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyOnline.Repository
{
    public class VideoRepository
    {
        private readonly StudyOnline.Entities.Models.StudyOnline _db = null;

        public VideoRepository()
        {
            _db = new Entities.Models.StudyOnline();
        }

      
        public List<StudyOnline.Entities.Models.Video> ListAllVideo()
        {
            return _db.Video.ToList();
        }

     
        public StudyOnline.Entities.Models.Video ViewDetail(long id)
        {
            return _db.Video.Find(id);
        }

     
        public long InsertVideo(StudyOnline.Entities.Models.Video tq)
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

       
        public bool UpdateVideo(StudyOnline.Entities.Models.Video v)
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
            catch (Exception) {
                return false;
            }
        }

       
        public bool DeleteVideo(long id)
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
