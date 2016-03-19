﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyOnline.Repository.Interface
{
    public interface ICommentRepository
    {
        List<StudyOnline.Entities.Models.Comment> ListAllComment();
        StudyOnline.Entities.Models.Comment ViewDetail(long id);
        long InsertComment(StudyOnline.Entities.Models.Comment com);
        bool UpdateComment(StudyOnline.Entities.Models.Comment com);
        bool DeleteComment(long id);
    }
}
