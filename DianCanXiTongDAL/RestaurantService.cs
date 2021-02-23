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
            return db.GetTable(sql, "Restaurant", sp);
        }
        public List<Restaurant> Longin(string uid,string pwd)//餐厅登录
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
