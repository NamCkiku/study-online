using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyOnline.Repository.Users
{
    public interface IUserRepository
    {
        List<StudyOnline.Entities.Models.User> ListAllUser();
        List<StudyOnline.Entities.Models.User> GetUserById(long id);
        StudyOnline.Entities.Models.User ViewDetail(long id);
        long CreateUser(StudyOnline.Entities.Models.User tq);
        bool UpdateUser(StudyOnline.Entities.Models.User us);
        bool DeleteUser(long id);
        int Login(string userName, string password);
        bool Signup(StudyOnline.Entities.Models.User user);
        void Active(int id, bool status);
        bool CheckUserName(string userName);
        bool CheckEmail(string email);
        StudyOnline.Entities.Models.User GetById(string userName);
    }
}
