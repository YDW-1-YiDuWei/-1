using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DianCanXiTongManager
{
    public class DiningComment
    {
        public int id { get; set; }//标识列ID
        public int RestaurantId { get; set; }//餐厅ID
        public string DiningComments { get; set; }//餐厅评论  
        public double DiningGrade { get; set; }//餐厅评分
        public int ClientId { get; set; }//用户ID
    }
}
