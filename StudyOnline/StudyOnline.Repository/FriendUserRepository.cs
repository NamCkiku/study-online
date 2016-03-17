using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyOnline.Repository
{
    public class FriendUserRepository
    {
        /// <summary>
        /// Lấy danh sách bạn bè
        /// </summary>
        /// <returns>List</returns>
        public List<StudyOnline.Entities.Models.FriendUser> ListAllFriendUser()
        {
            using (StudyOnline.Entities.Models.StudyOnline _db = new StudyOnline.Entities.Models.StudyOnline())
            {
                return _db.FriendUser.ToList();
            }
        }

        /// <summary>
        /// Lấy thông tin 1 bạn
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>FriendUser</returns>
        public StudyOnline.Entities.Models.FriendUser ViewDetail(long id)
        {
            using (StudyOnline.Entities.Models.StudyOnline _db = new StudyOnline.Entities.Models.StudyOnline())
            {
                return _db.FriendUser.Find(id);
            }
        }

        /// <summary>
        /// Thêm bạn bè
        /// </summary>
        /// <param name="friend">FriendUser</param>
        /// <returns>long</returns>
        public long InsertFriendUser(StudyOnline.Entities.Models.FriendUser friend)
        {
            using (StudyOnline.Entities.Models.StudyOnline _db = new StudyOnline.Entities.Models.StudyOnline())
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
        }


        /// <summary>
        /// Xóa bạn bè
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>bool</returns>
        public bool DeleteFriendUser(long id)
        {
            using (StudyOnline.Entities.Models.StudyOnline _db = new StudyOnline.Entities.Models.StudyOnline())
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
}
