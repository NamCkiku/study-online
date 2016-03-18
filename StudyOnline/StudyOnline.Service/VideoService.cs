using StudyOnline.Repository;
using StudyOnline.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyOnline.Service
{
    public class VideoService : IVideoService
    {
        VideoRepository videoRepository = new VideoRepository();
        public List<StudyOnline.Entities.Models.Video> ListAllVideo()
        {
            return videoRepository.ListAllVideo();
        }
        public StudyOnline.Entities.Models.Video ViewDetail(long id)
        {
            return videoRepository.ViewDetail(id);
        }
        public long InsertVideo(StudyOnline.Entities.Models.Video tq)
        {
            return videoRepository.InsertVideo(tq);
        }
        public bool UpdateVideo(StudyOnline.Entities.Models.Video v)
        {
            return videoRepository.UpdateVideo(v);
        }
        public bool DeleteVideo(long id)
        {
            return videoRepository.DeleteVideo(id);
        }
    }
}
