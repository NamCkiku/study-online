using StudyOnline.Repository;
using StudyOnline.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyOnline.Service
{
    public class SecctionService : ISecctionService
    {
        SecctionRepository rpSecction = new SecctionRepository();
        public List<StudyOnline.Entities.Models.Section> ListAllSection()
        {
            return rpSecction.ListAllSection();
        }
        public StudyOnline.Entities.Models.Section ViewDetail(long id)
        {
            return rpSecction.ViewDetail(id);
        }
        public long CreateSection(StudyOnline.Entities.Models.Section sec)
        {
            return rpSecction.CreateSection(sec);
        }
        public bool UpdateSection(StudyOnline.Entities.Models.Section sec)
        {
            return rpSecction.UpdateSection(sec);
        }
        public bool DeleteSection(long id)
        {
            return rpSecction.DeleteSection(id);
        }
    }
}
