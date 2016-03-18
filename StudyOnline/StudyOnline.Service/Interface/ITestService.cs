﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyOnline.Service.Interface
{
    public interface ITestService
    {
        List<StudyOnline.Entities.Models.Test> ListAllTest();
        StudyOnline.Entities.Models.Test ViewDetail(long id);
        long CreateTest(StudyOnline.Entities.Models.Test tes);
        bool UpdateTest(StudyOnline.Entities.Models.Test tes);
        bool DeleteTest(long id);
    }
}
