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
        public DataTable InquireRestaurantName(string name) 
        {
            return restauranSer.InquireRestaurantName(name);
        }
    }
}
