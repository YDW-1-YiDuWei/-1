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
        /// <summary>
        /// 查询餐馆全部
        /// </summary>
        public DataTable InquireRestaurant() 
        {
            DataTable dt = new DataTable();
            return dt;
        }
        public List<Restaurant> Longin(string uid,string pwd)
        {
            List<Restaurant> list = new List<Restaurant>();

            DBHelper db=new DBHelper();

            Restaurant rest = null;

            string sql = "select RestaurantNumber,RestaurantNumberPwd from Restaurant where RestaurantNumber=@RestaurantNumber and RestaurantNumberPwd=@RestaurantNumberPwd";

            SqlParameter[] sp =
            {
                new SqlParameter("@RestaurantNumber",uid),
                new SqlParameter("@RestaurantNumberPwd",pwd)
            };
            SqlDataReader sdr = db.ExecuteReader(sql, sp);
            if (sdr.Read())
            {
                rest = new Restaurant
                {
                    RestaurantNumber = sdr["RestaurantNumber"].ToString(),
                    RestaurantNumberPwd = sdr["RestaurantNumberPwd"].ToString()
                };
                list.Add(rest);
            }
            return list;
        }
    }
}
