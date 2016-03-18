using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyOnline.Service.Interface
{
    public interface ISecctionService
    {
        List<StudyOnline.Entities.Models.Section> ListAllSection();
        StudyOnline.Entities.Models.Section ViewDetail(long id);
        long CreateSection(StudyOnline.Entities.Models.Section sec);
        bool UpdateSection(StudyOnline.Entities.Models.Section sec);
        bool DeleteSection(long id);
    }
}
