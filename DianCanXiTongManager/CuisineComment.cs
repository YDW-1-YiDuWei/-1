using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DianCanXiTongManager
{
    public class CuisineComment
    {
        public int id { get; set; }//标识列ID
        public int CuisineId { get; set; }//菜品ID
        public string CuisineComments { get; set; }//菜品评论 
        public int CuisineRate { get; set; }//菜品评级
        public int ClientId { get; set; }//用户ID
    }
}
