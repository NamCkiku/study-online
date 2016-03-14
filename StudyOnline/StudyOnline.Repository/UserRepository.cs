using StudyOnline.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace StudyOnline.Repository
{
    public class UserRepository
    {
        private readonly StudyOnline.Entities.Models.StudyOnline _db = null;

        public UserRepository()
        {
            _db = new Entities.Models.StudyOnline();
        }


        public List<StudyOnline.Entities.Models.User> ListAllUser()
        {
            return _db.User.ToList();
        }


        public StudyOnline.Entities.Models.User ViewDetail(long id)
        {
            return _db.User.Find(id);
        }


        public long CreateUser(StudyOnline.Entities.Models.User tq)
        {
            try
            {
                _db.User.Add(tq);
                _db.SaveChanges();
                return tq.ID;
            }
            catch (Exception)
            {
                return -1;
            }
        }


        public bool UpdateUser(StudyOnline.Entities.Models.User us)
        {
            try
            {
                var c = _db.User.Find(us.ID);
                c.UserName = us.UserName;
                c.Password = us.Password;
                c.Name = us.Name;
                c.Address = us.Address;
                c.Email = us.Email;
                c.Phone = us.Phone;
                c.Avatar = us.Avatar;
                c.Status = us.Status;
                c.CreatedDate = us.CreatedDate;
                c.CreatedBy = us.CreatedBy;
                c.ModifiedDate = us.ModifiedDate;
                c.ModifiedBy = us.ModifiedBy;
                c.GroupID = us.GroupID;
                c.PayID = us.PayID;
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public bool DeleteUser(long id)
        {
            try
            {
                var result = _db.User.Find(id);
                _db.User.Remove(result);
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public int Login(string userName, string password)
        {
            var result = _db.User.SingleOrDefault(x => x.UserName == userName && x.Password == password);//lấy giá trị của User Name
            if (result == null)//Nếu bằng null
            {
                return 0;//Nhập Tài Khoản Và Mật Khẩu
            }
            else    //Khác Null
            {
                if (result.Status == false)//Trạng Thaí = False
                {
                    return -1;  //Tài Khoản Đang Bị Khóa
                }
                else  //Trạng Thái == true
                {
                    if (result.Password == password)  //Nếu Password đúng
                        return 1; //Đăng Nhập Thành Công
                    else
                        return -2; //Sai tài khoản và mật khẩu
                }
            }
        }
        public bool Signup(User user)
        {
            if (user != null)
            {
                var User = _db.User.Add(user);
                _db.SaveChanges();
                return true;
            }
            else
                return false;
        }
        public void Active(int id, bool status)
        {
            var data = _db.User.SingleOrDefault(x => x.ID == id);
            data.Status = true;
            _db.SaveChanges();
        }

        //public void Register(User models, HttpPostedFileBase file)
        //{
        //    var fileName = GetDateName() + "_" + Path.GetFileName(file.FileName);
        //    var path = Path.Combine(Server.MapPath("~/Uploads/files/imageuser/"), fileName);
        //    var a = file.ContentType;
        //    var b = file.ContentLength;
        //    if ((a.Equals("image/jpeg") || a.Equals("image/jpg") || a.Equals("image/png")) && b < 4194304)
        //    {
        //        file.SaveAs(path);
        //    }
        //    else
        //    {
        //        ViewBag.Message = "Kieu file(.png, .jpg,jpeg) va nho hon 4MB";
        //        return View("ViewRegister", models);
        //    }
        //    var filepathToSave = "/Uploads/files/imageuser/" + fileName;
        //    if (ModelState.IsValid)
        //    {
        //        var kt = db.Users.Where(x => x.UserName.Equals(models.UserName)).ToList();
        //        var mail = db.Users.Where(x => x.Email.Equals(models.Email)).ToList();
        //        if (kt.Count == 0 && mail.Count == 0)
        //        {
        //            if (models.Captcha.Equals(Session["captcha"].ToString()))
        //            {
        //                User data = new User()
        //                {
        //                    Code = models.Code,
        //                    Money = 0,
        //                    Password = models.Password,
        //                    Phone = models.Phone,
        //                    Email = models.Email,
        //                    Role = "member",
        //                    UserName = models.UserName,
        //                    Active = false,
        //                    ImageUrl = filepathToSave,
        //                    History = false
        //                };
        //                db.Users.Add(data);
        //                db.SaveChanges();
        //                //
        //                var maxid = db.Users.Max(x => x.UserId);
        //                //tao link de gui
        //                var u = Request.Url.Authority;
        //                var link = "http://" + u + "/User/ActiveAcc?id=" + maxid + "&active=true";
        //                PageHelp.SendMail("Kích hoạt tài khoản xổ số", "Ban click vào link de kich hoat tai khoan: " + link, "bondt90@gmail.com", "niutonoo12", models.Email, "bondt90");
        //                //
        //                ViewBag.Message = "Ban da dang ky thanh cong, xin moi vao hom thu de kich hoat";
        //                return View("ViewRegister");
        //            }
        //            ViewBag.Message = "Ma bao ve chua dung";
        //        }
        //        else
        //        {
        //            ViewBag.Message = "Tai khoan da ton tai hoac emali da ton tai";
        //        }

        //    }
        //    return View("ViewRegister", models);
        //}
    }
}
