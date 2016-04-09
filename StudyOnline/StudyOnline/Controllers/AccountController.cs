using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudyOnline.Common;
using StudyOnline.Entities.Models;
using StudyOnline.Service.Users;
using System.IO;
using Facebook;
using System.Configuration;

namespace StudyOnline.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/
        StudyOnline.Entities.Models.StudyOnline db = new Entities.Models.StudyOnline();
        UserService userService = new UserService();
        private string sessionId = "";
        public ActionResult Index()
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

        public ActionResult GetSessionId()
        {
            return Json( Session["UserID"].ToString(), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User model)
        {
            if (Request.Files != null && Request.Files.Count > 0)
            {
                HttpPostedFileBase file = Request.Files[0];
                if (file != null && file.ContentLength > 0)
                {
                }

                var fileName = GetDateName() + "_" + Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Contents/img/"), fileName);
                var a = file.ContentType;
                var b = file.ContentLength;

                if ((a.Equals("image/jpeg") || a.Equals("image/jpg") || a.Equals("image/png")) && b < 4194304)
                {
                    file.SaveAs(path);
                }
                else
                {
                    ViewBag.Message = "Kieu file(.png, .jpg,jpeg) va nho hon 4MB";
                    return View("ViewRegister", model);
                }
                var filepathToSave = "/Contents/img/" + fileName;
                if (ModelState.IsValid)
                {
                    var kt = db.User.SingleOrDefault(x => x.UserName == model.UserName);
                    var mail = db.User.SingleOrDefault(x => x.Email == model.Email);
                    if (kt == null && mail == null)
                    {
                        userService.CreateUser(model);
                        var maxid = db.User.Max(x => x.ID);
                        //tao link de gui
                        var u = Request.Url.Authority;
                        var link = "http://" + u + "/Account/ActiveAcc?id=" + maxid + "&active=true";
                        SendMail.SendGmail("Kích hoạt tài khoản", "Ban click vào link de kich hoat tai khoan: " + link, "quanchux5@gmail.com", "chuvanquan96", model.Email, "quanchux5@gmail.com");
                        ViewBag.Message = "Ban da dang ky thanh cong, xin moi vao hom thu de kich hoat";
                        return View("Login");
                    }
                    else
                    {
                        ViewBag.Message = "Tai khoan da ton tai hoac emali da ton tai";
                    }

                }
            }
            return View("Login", model);
        }

        public ActionResult ActiveAcc(int id, bool active)
        {
            if (active)
            {
                RedirectToAction("Index", "Home");
            }
            userService.Active(id, active);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }

        public ActionResult GetPassword(User model)
        {
            if (ModelState.IsValid)
            {
                //var data = db.User.Where(x => x.UserName == model.UserName && x.Email == model.Email).ToList();
                if (userService.CheckEmail(model.Email) && userService.CheckUserName(model.UserName))
                {
                    var newpass = SendMail.RandomString(6);
                    var dataUpdate = db.User.SingleOrDefault(x => x.UserName == model.UserName);
                    dataUpdate.Password = newpass;
                    db.SaveChanges();
                    SendMail.SendGmail("Lay lai mat khau", "Mat khau moi cua ban la: " + newpass, "quanchux5@gmail.com", " chuvanquan96", model.Email, "quanchux5@gmail.com");
                    ViewBag.Message = "Mật khẩu đã được gửi đến hòm thư của bạn !";
                }
                else
                {
                    ViewBag.Message = "Opps...! Tài khoản hoặc email không tồn tại.";
                }
            }
            return View("Login");
        }

        [Authorize]
        public ActionResult ViewChangePass()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult ChangePass(User models)
        {
            var data = db.User.Single(u => u.UserName.Equals(System.Web.HttpContext.Current.User.Identity.Name));
            if (data.Password == models.Password)
            {
                data.Password = models.Password;
                db.SaveChanges();
                ViewBag.Message = "Thay đổi thành công";
            }
            else
            {
                ViewBag.Message = "Password cũ không đúng";
            }
            return View("ViewChangePass");
        }

        private static string GetDateName()
        {
            return DateTime.Now.ToString("yyyyMMddhhmmssms");
        }

        private Uri RedirectUri
        {
            get
            {
                var uriBuilder = new UriBuilder(Request.Url);
                uriBuilder.Query = null;
                uriBuilder.Fragment = null;
                uriBuilder.Path = Url.Action("FacebookCallBack");
                return uriBuilder.Uri;
            }
        }
        public ActionResult LoginFacebook()
        {
            var fb = new FacebookClient();
            var loginUrl = fb.GetLoginUrl(
                new
                {
                    client_id = ConfigurationManager.AppSettings["FBAppID"],
                    client_secret = ConfigurationManager.AppSettings["FBAppSecret"],
                    redirect_uri = RedirectUri.AbsoluteUri,
                    response_type = "code",
                    scope = "email",
                });
            return Redirect(loginUrl.AbsoluteUri);
        }
        public ActionResult FacebookCallBack(string code)
        {
            var fb = new FacebookClient();
            dynamic result = fb.Post("oauth/access_token", new
            {
                client_id = ConfigurationManager.AppSettings["FBAppID"],
                client_secret = ConfigurationManager.AppSettings["FBAppSecret"],
                redirect_uri = RedirectUri.AbsoluteUri,
                code = code
            });
            var accsessToken = result.access_token;
            if (!string.IsNullOrEmpty(accsessToken))
            {
                fb.AccessToken = accsessToken;
                dynamic me = fb.Get("me?fields=first_name,middle_name,last_name,id,email");
                var uid = "http://graph.facebook.com/" + me.id + "/picture?type=square";
                string email = me.email;
                string userName = me.email;
                string firstname = me.first_name;
                string middlename = me.middle_name;
                string lastname = me.last_name;
                //string phone = me.mobile_phone;

                var user = new User();
                user.Email = email;
                user.UserName = email;
                user.Status = true;
                user.Avatar = uid;
                //user.Phone = phone;
                user.Name = firstname + " " + middlename + " " + lastname;
                user.CreatedDate = DateTime.Now;
                var resultInsert = userService.InsertForFacebook(user);
                if (resultInsert > 0)
                {
                    var userSession = new UserLogin();
                    userSession.UserName = user.UserName;
                    userSession.UserID = user.ID;
                    userSession.Avatar = user.Avatar;
                    Session.Add(Common.CommonConstants.USER_SESSION, userSession); //Thêm vào Session
                }
            }
            else
            {

            }
            return Redirect("/");
        }
    }
}