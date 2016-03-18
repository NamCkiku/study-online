using StudyOnline.Repository;
using StudyOnline.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyOnline.Service
{
    public class CommentService : ICommentService
    {
        CommentRepository comentRepository = new CommentRepository();
        public List<StudyOnline.Entities.Models.Comment> ListAllComment()
        {
            return comentRepository.ListAllComment();
        }
        public StudyOnline.Entities.Models.Comment ViewDetail(long id)
        {
            return comentRepository.ViewDetail(id);
        }
        public long InsertComment(StudyOnline.Entities.Models.Comment com)
        {
            return comentRepository.InsertComment(com);
        }
        public bool UpdateComment(StudyOnline.Entities.Models.Comment com)
        {
            return comentRepository.UpdateComment(com);
        }
        public bool DeleteComment(long id)
        {
            return comentRepository.DeleteComment(id);
        }
    }
}
