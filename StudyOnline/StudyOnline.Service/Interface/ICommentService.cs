using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyOnline.Service.Interface
{
    public interface ICommentService
    {
        List<StudyOnline.Entities.Models.Comment> ListAllComment();
        StudyOnline.Entities.Models.Comment ViewDetail(long id);
        long InsertComment(StudyOnline.Entities.Models.Comment com);
        bool UpdateComment(StudyOnline.Entities.Models.Comment com);
        bool DeleteComment(long id);
    }
}
