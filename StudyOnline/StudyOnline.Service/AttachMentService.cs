
using StudyOnline.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyOnline.Repository.Interface;

namespace StudyOnline.Service
{
    public class AttachmentService : IAttachmentService
    {
        private readonly IAttachMentRepository attachmentRepository;
        public AttachmentService(IAttachMentRepository repository)
        {
            attachmentRepository = repository;
        }

        public List<StudyOnline.Entities.Models.AttachMent> ListAllAttachMent()
        {
            return attachmentRepository.ListAllAttachMent();
        }
        public StudyOnline.Entities.Models.AttachMent ViewDetail(long id)
        {
            return attachmentRepository.ViewDetail(id);
        }
        public long InsertAttachMent(StudyOnline.Entities.Models.AttachMent am)
        {
            return attachmentRepository.InsertAttachMent(am);
        }
        public bool UpdateAttachMent(StudyOnline.Entities.Models.AttachMent am)
        {
            return attachmentRepository.UpdateAttachMent(am);
        }
        public bool DeleteAttachMent(long id)
        {
            return attachmentRepository.DeleteAttachMent(id);
        }
    }
}
