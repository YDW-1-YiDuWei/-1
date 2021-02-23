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
    public class RestaurantManvace
    {
        RestaurantService restauranSer = new RestaurantService();
        /// <summary>
        /// 查询餐馆全部
        /// </summary>
        public DataTable InquireRestaurant() 
        {
            return restauranSer.InquireRestaurant();
        }
    }
}
