using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyOnline.Service.Interface
{
    public interface IAttachmentService
    {
        List<StudyOnline.Entities.Models.AttachMent> ListAllAttachMent();
        StudyOnline.Entities.Models.AttachMent ViewDetail(long id);
        long InsertAttachMent(StudyOnline.Entities.Models.AttachMent am);
        bool UpdateAttachMent(StudyOnline.Entities.Models.AttachMent am);
        bool DeleteAttachMent(long id);
    }
}
