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
            SqlParameter[] sp = new SqlParameter[]
            {
            new SqlParameter("@Name",name)
            };
            if (name != "")
            {
                sql += " and RestaurantName like '%" + name + "%'";
            }

            return db.GetTable(sql, "Restaurant");
        }
        public int InquireRestaurantNameCount(string name) // 根据餐馆名字查询然后知道多少的餐馆
        {
            string sql = "select count(0) from Restaurant where 1=1";
            SqlParameter[] sp = new SqlParameter[]
            {
            new SqlParameter("@Name",name)
            };
            if (name != "")
            {
                sql += " and RestaurantName like '%" + name + "%'";
            }

            return (int)db.ExecuteScalar(sql);
        }
        public List<Restaurant> Longin(string uid, string pwd)//餐厅登录
        {
            SqlConnection coon = new SqlConnection("server=.;database=Order;uid=sa;pwd=sa");

            List<Restaurant> list = new List<Restaurant>();

            DBHelper db = new DBHelper();

            Restaurant rest = null;
            string sql = "select Id, RestaurantNumber, RestaurantNumberPwd, RestaurantName, RestaurantAddress, RestaurantPhone, RestaurantComment, RestaurantImage from Restaurant where RestaurantNumber=@RestaurantNumber and RestaurantNumberPwd=@RestaurantNumberPwd";


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
                    id = (int)sdr["Id"],
                    RestaurantNumber = sdr["RestaurantNumber"].ToString(),
                    RestaurantNumberPwd = sdr["RestaurantNumberPwd"].ToString(),
                    RestaurantName = sdr["RestaurantName"].ToString(),
                    RestaurantAddress = sdr["RestaurantAddress"].ToString(),
                    RestaurantPhone = sdr["RestaurantPhone"].ToString(),
                    RestaurantComment = sdr["RestaurantComment"].ToString(),
                    RestaurantImage = sdr["RestaurantImage"].ToString()
                };
                list.Add(rest);
            }
            coon.Close();
            return list;
        }

        /// <summary>
        /// 餐馆注册
        /// </summary>
        /// <param name="uid">餐馆账号</param>
        /// <param name="pwd">餐馆密码</param>
        /// <param name="name">餐馆姓名</param>
        /// <param name="address">餐馆地址</param>
        /// <param name="phone">餐馆电话</param>
        /// <param name="comment">餐馆评论</param>
        /// <param name="image">餐馆图片路径</param>
        /// <returns></returns>
        public List<Restaurant> Register(string uid, string pwd,string name,string address,string phone,string comment,string image)
        {
            SqlConnection coon = new SqlConnection("server=.;database=Order;uid=sa;pwd=sa");

            List<Restaurant> list = new List<Restaurant>();

            DBHelper db = new DBHelper();

            Restaurant rest = null;
            string sql = "insert into Restaurant(RestaurantNumber, RestaurantNumberPwd, RestaurantName, RestaurantAddress, RestaurantPhone, RestaurantComment, RestaurantImage) values(@RestaurantNumber,@RestaurantNumberPwd,@RestaurantName,@RestaurantAddress,@RestaurantPhone,@RestaurantComment,@RestaurantImage)";


            SqlParameter[] sp =
            {
                new SqlParameter("@RestaurantNumber", uid),
                new SqlParameter("@RestaurantNumberPwd", pwd),
                new SqlParameter("@RestaurantName",name),
                new SqlParameter("@RestaurantAddress",address),
                new SqlParameter("@RestaurantPhone",phone),
                new SqlParameter("@RestaurantComment",comment),
                new SqlParameter("@RestaurantImage",image),
            };
            coon.Open();
            SqlCommand cmd = new SqlCommand(sql, coon);
            cmd.Parameters.AddRange(sp);
            int sdr = cmd.ExecuteNonQuery();
            if (sdr > 0)
            {
                rest = new Restaurant
                {
                   
                    RestaurantNumber = uid,
                    RestaurantNumberPwd = pwd,
                    RestaurantName = name,
                    RestaurantAddress = address,
                    RestaurantPhone = phone,
                    RestaurantComment = comment,
                    RestaurantImage = image
                };
                list.Add(rest);
            }
            coon.Close();
            return list;
        }
    }
}
