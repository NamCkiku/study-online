using StudyOnline.Common;
using StudyOnline.Entities.Models;
using StudyOnline.Service.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudyOnline.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        StudyOnline.Entities.Models.StudyOnline db = new Entities.Models.StudyOnline();
        UserService userService = new UserService();
        private string sessionId = "";
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ListCourseOfUser()
        {
            return View();
        }
        public ActionResult UpdateUser()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User model)
        {
            var result = userService.Login(model.UserName, model.Password);
            if (result == 1)
            {
                var user = userService.GetById(model.UserName);
                var userSession = new UserLogin();
                userSession.UserName = user.UserName;
                userSession.UserID = user.ID;
                Session["UserID"] = user.ID;
                sessionId = Session["UserID"].ToString();
                Session.Add(Common.CommonConstants.USER_SESSION, userSession); //Thêm vào Session
                return RedirectToAction("Index", "Home");
            }
            else if (result == 0) //Nếu tên tài khoản bằng 0
            {
                ModelState.AddModelError("", "Sai Tài Khoản Hoặc Mật Khẩu");
            }
            else if (result == -1) //Nếu Trạng Thái bằng False
            {
                ModelState.AddModelError("", "Tài Khoản Đang Bị Khóa");
            }
            else if (result == -2) //Nếu Tài Khoản Sai
            {
                ModelState.AddModelError("", "Mật Khẩu Không Đúng");
            }
            else  //nẾU tÀI khoản Không đúng
            {
                ModelState.AddModelError("", "Đăng Nhập Không Thành Công");
            }
            return View("Login");
        }

    }
}