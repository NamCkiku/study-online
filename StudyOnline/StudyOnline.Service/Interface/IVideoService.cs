using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyOnline.Service.Interface
{
    public interface IVideoService
    {
        List<StudyOnline.Entities.Models.Video> ListAllVideo();
        StudyOnline.Entities.Models.Video ViewDetail(long id);
        long InsertVideo(StudyOnline.Entities.Models.Video tq);
        bool UpdateVideo(StudyOnline.Entities.Models.Video v);
        bool DeleteVideo(long id);
    }
}
