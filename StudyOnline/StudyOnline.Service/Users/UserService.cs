﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyOnline.Entities.Models;
using StudyOnline.Repository.Users;
using StudyOnline.Entities.ModelsView;

namespace StudyOnline.Service.Users
{

    public class UserService : IUserService
    {
        //public readonly IUserRepository userRepository;

        //public UserService(IUserRepository userRepository)
        //{
        //    this.userRepository = userRepository;
        //}
        UserRepository userRepository = new UserRepository();
        public List<StudyOnline.Entities.Models.User> ListAllUser()
        {
            return userRepository.ListAllUser();
        }
        public StudyOnline.Entities.Models.User ViewDetail(long id)
        {
            return userRepository.ViewDetail(id);
        }
        public StudyOnline.Entities.Models.User GetById(string userName)
        {
            return userRepository.GetById(userName);
        }
        public long CreateUser(StudyOnline.Entities.Models.User tq)
        {
            return userRepository.CreateUser(tq);
        }
        public bool UpdateUser(StudyOnline.Entities.Models.User us)
        {
            return userRepository.UpdateUser(us);
        }
        public bool DeleteUser(long id)
        {
            return userRepository.DeleteUser(id);
        }
        public int Login(string userName, string password)
        {
            return userRepository.Login(userName, password);
        }
        public bool Signup(User user)
        {
            return userRepository.Signup(user);
        }
        public void Active(int id, bool status)
        {
            userRepository.Active(id, status);
        }


        public bool CheckEmail(string email)
        {
            return userRepository.CheckEmail(email);
        }

        public bool CheckUserName(string userName)
        {
            return userRepository.CheckUserName(userName);
        }
        public long InsertForFacebook(User entity)
        {
            return userRepository.InsertForFacebook(entity);
        }

        public List<User> GetUserById(long id)
        {
            return userRepository.GetUserById(id);
        }


        public List<UserCourseModels> GetListByTearcherId(long id)
        {
            return userRepository.GetListByTearcherId(id);
        }
    }
}
