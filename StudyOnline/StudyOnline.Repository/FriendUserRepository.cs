using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyOnline.Repository
{
    public class FriendUserRepository
    {
        private readonly StudyOnline.Entities.Models.StudyOnline _db = null;

        public FriendUserRepository()
        {
            _db = new Entities.Models.StudyOnline();
        }

        // Lấy danh sách bạn bè
        public List<StudyOnline.Entities.Models.FriendUser> ListAllFriendUser()
        {
            return _db.FriendUser.ToList();
        }

        //Lấy thông tin 1 bạn bè
        public StudyOnline.Entities.Models.FriendUser ViewDetail(long id)
        {
            return _db.FriendUser.Find(id);
        }

        //Add bạn bè
        public long InsertFriendUser(StudyOnline.Entities.Models.FriendUser friend)
        {
            try
            {
                _db.FriendUser.Add(friend);
                _db.SaveChanges();
                return friend.FriendID;
            }
            catch (Exception)
            {
                return -1;
            }
        }


        //Xóa bạn bè
        public bool DeleteFriendUser(long id)
        {
            try
            {
                var result = _db.FriendUser.Find(id);
                _db.FriendUser.Remove(result);
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
