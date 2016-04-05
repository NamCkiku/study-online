using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyOnline.Entities.Models;

namespace StudyOnline.Entities.ModelsView
{
    public class UserCourseModels
    {
        public long CourseID { get; set; }
        public string CourseName { get; set; }
        public string Avatar { get; set; }
        public string Description { get; set; }
        public double PriceSale { get; set; }
        public double Price { get; set; }
        public int ViewCount { get; set; }
        public DateTime CreateDate { get; set; }
        public long UserID { get; set; }
        public string UserName { get; set; }

        public UserCourseModels(long CourseID, string CourseName, string Avatar,string Description, double PriceSale ,double Price ,int ViewCount, DateTime CreateDate,long UserID ,string UserName )
        {
            this.CourseID = CourseID;
            this.CourseName = CourseName;
            this.Avatar = Avatar;
            this.Description = Description;
            this.PriceSale = PriceSale;
            this.Price = Price;
            this.ViewCount = ViewCount;
            this.CreateDate = CreateDate;
            this.UserID = UserID;
            this.UserName = UserName;
        }

        public UserCourseModels()
        { }
    }
}
