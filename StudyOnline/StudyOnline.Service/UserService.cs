using StudyOnline.Entities.Models;
using StudyOnline.Repository;
using StudyOnline.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyOnline.Service
{

    public class UserService : IUserService
    {
        UserRepository usrepository = new UserRepository();
        public List<StudyOnline.Entities.Models.User> ListAllUser()
        {
            return usrepository.ListAllUser();
        }
        public StudyOnline.Entities.Models.User ViewDetail(long id)
        {
            return usrepository.ViewDetail(id);
        }
        public StudyOnline.Entities.Models.User GetById(string userName)
        {
            return usrepository.GetById(userName);
        }
        public long CreateUser(StudyOnline.Entities.Models.User tq)
        {
            return usrepository.CreateUser(tq);
        }
        public bool UpdateUser(StudyOnline.Entities.Models.User us)
        {
            return usrepository.UpdateUser(us);
        }
        public bool DeleteUser(long id)
        {
            return usrepository.DeleteUser(id);
        }
        public int Login(string userName, string password)
        {
            return usrepository.Login(userName, password);
        }
        public bool Signup(User user)
        {
            return usrepository.Signup(user);
        }
        public void Active(int id, bool status)
        {
            usrepository.Active(id, status);
        }
    }
}
