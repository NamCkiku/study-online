using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyOnline.Repository.Interface
{
    public interface IAttachMentRepository
    {
        List<StudyOnline.Entities.Models.AttachMent> ListAllAttachMent();
        StudyOnline.Entities.Models.AttachMent ViewDetail(long id);
        long InsertAttachMent(StudyOnline.Entities.Models.AttachMent am);
        bool UpdateAttachMent(StudyOnline.Entities.Models.AttachMent am);
        bool DeleteAttachMent(long id);
    }
}
