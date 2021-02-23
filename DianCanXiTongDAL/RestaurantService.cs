using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DianCanXiTongManager;
using System.Data;
using System.Data.SqlClient;

namespace DianCanXiTongDAL
{
    public class RestaurantService//餐馆数据层
    {
        DBHelper db = new DBHelper();
        /// <summary>
        /// 根据餐馆名字查询
        /// </summary>
        public DataTable InquireRestaurantName(string name) 
        {
            string sql = "select * from Restaurant where RestaurantName=@RestaurantName";
            SqlParameter[] sp = new SqlParameter[]
            {
            new SqlParameter("@RestaurantName",name)
            };

            DataTable dt = new DataTable();
            return dt;
        }
    }
}
