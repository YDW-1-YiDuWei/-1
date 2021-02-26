using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DianCanXiTongManager
{
    public class Restaurant
    {
        public int id { get; set; }//标识列ID
        public string RestaurantNumber { get; set; }//后面增加的餐馆账号
        public string RestaurantNumberPwd { get; set; }//后面增加的餐馆账号
        public string RestaurantName { get; set; }//餐馆名称 
        public string RestaurantAddress { get; set; }//餐馆地址
        public string RestaurantPhone { get; set; }//餐馆电话
        public string RestaurantComment { get; set; }//餐馆评论
        public string RestaurantImage { get; set; }//餐馆图片路径
    }
}
