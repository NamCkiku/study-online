using StudyOnline.Repository;
using StudyOnline.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyOnline.Service
{
    public class TestService : ITestService
    {
        TestRepository testRepository = new TestRepository();
        public List<StudyOnline.Entities.Models.Test> ListAllTest()
        {
            return testRepository.ListAllTest();
        }
        public StudyOnline.Entities.Models.Test ViewDetail(long id)
        {
            return testRepository.ViewDetail(id);
        }
        public long CreateTest(StudyOnline.Entities.Models.Test tes)
        {
            return testRepository.CreateTest(tes);
        }
        public bool UpdateTest(StudyOnline.Entities.Models.Test tes)
        {
            return testRepository.UpdateTest(tes);
        }
        public bool DeleteTest(long id)
        {
            return testRepository.DeleteTest(id);
        }
    }
}
