using StudyOnline.Repository;
using StudyOnline.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyOnline.Service
{
    public class AttachMentService : IAttachMentService
    {
        AttachMentRepository amtRepository = new AttachMentRepository();
        public List<StudyOnline.Entities.Models.AttachMent> ListAllAttachMent()
        {
            return amtRepository.ListAllAttachMent();
        }
        public StudyOnline.Entities.Models.AttachMent ViewDetail(long id)
        {
            return amtRepository.ViewDetail(id);
        }
        public long InsertAttachMent(StudyOnline.Entities.Models.AttachMent am)
        {
            return amtRepository.InsertAttachMent(am);
        }
        public bool UpdateAttachMent(StudyOnline.Entities.Models.AttachMent am)
        {
            return amtRepository.UpdateAttachMent(am);
        }
        public bool DeleteAttachMent(long id)
        {
            return amtRepository.DeleteAttachMent(id);
        }
    }
}
