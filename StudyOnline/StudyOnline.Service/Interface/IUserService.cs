﻿using StudyOnline.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyOnline.Service.Interface
{
    public interface IUserService
    {
        List<StudyOnline.Entities.Models.User> ListAllUser();
        StudyOnline.Entities.Models.User ViewDetail(long id);
        long CreateUser(StudyOnline.Entities.Models.User tq);
        bool UpdateUser(StudyOnline.Entities.Models.User us);
        bool DeleteUser(long id);
        int Login(string userName, string password);
        bool Signup(User user);
        void Active(int id, bool status);
    }
}
