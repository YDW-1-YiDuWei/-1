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
        public DataTable InquireRestaurantName(string name) // 根据餐馆名字查询
        {
            string sql = "select * from Restaurant where 1=1";
            if (name!="")
            {
                sql += " and RestaurantName like '%@RestaurantName%'";
            }
            SqlParameter[] sp = new SqlParameter[]
            {
            new SqlParameter("@RestaurantName",name)
            };
            return db.GetTable(sql, "Restaurant", sp);
        }
        public List<Restaurant> Longin(string uid, string pwd)//餐厅登录
        {
            SqlConnection coon = new SqlConnection("server=.;database=Order;uid=sa;pwd=sa");

            List<Restaurant> list = new List<Restaurant>();

            DBHelper db = new DBHelper();

            Restaurant rest = null;

            string sql = "select RestaurantNumber,RestaurantNumberPwd from Restaurant where RestaurantNumber=@RestaurantNumber and RestaurantNumberPwd=@RestaurantNumberPwd";

            SqlParameter[] sp =
            {
                new SqlParameter("@RestaurantNumber",uid),
                new SqlParameter("@RestaurantNumberPwd",pwd)
            };
            coon.Open();
            SqlCommand cmd = new SqlCommand(sql, coon);
            cmd.Parameters.AddRange(sp);
            SqlDataReader sdr = cmd.ExecuteReader();
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
