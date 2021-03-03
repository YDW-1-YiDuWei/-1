using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DianCanXiTongDAL;
using DianCanXiTongManager;
using System.Data;

namespace DianCanXiTongBLL
{
    public class RestaurantManager
    {
        RestaurantService restauranSer = new RestaurantService();
        /// <summary>
        /// 查询餐馆全部
        /// </summary>
        public DataTable InquireRestaurantName(string name)//按名字查询餐馆
        {
            return restauranSer.InquireRestaurantName(name);
        }
        public int InquireRestaurantNameCount(string name) //按名字查询餐馆看有多少餐馆
        {
            return restauranSer.InquireRestaurantNameCount(name);
        }
        public List<Restaurant> Longin(string uid, string pwd)//餐厅登录
        {
            return restauranSer.Longin(uid, pwd);
        }
        public List<Restaurant> Register(string uid, string pwd, string name, string address, string phone, string comment, string image= "OIP.jpg", int count=0,int id=0)
        {
            return restauranSer.Register(uid,pwd,name,address,phone,comment,image,count,id);
        }
    }
}
