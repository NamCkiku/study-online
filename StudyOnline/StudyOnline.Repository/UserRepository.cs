using System;
using System.Collections.Generic;
using System.Linq;
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
            catch (Exception) {
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
    }
}
