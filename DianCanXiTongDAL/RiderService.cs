using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DianCanXiTongManager;
using System.Data.SqlClient;

namespace DianCanXiTongDAL
{
    /// <summary>
    /// 骑手数据层
    /// </summary>
    public class RiderService
    {
       

        /// <summary>
        ///  账户登录(可以获取当前登录的账号的全部信息)
        /// </summary>
        /// <param name="uid">传过来的账号</param>
        /// <param name="pwd">传过来的密码</param>
        /// <returns></returns>
        public List<Rider> Longin(string uid, string pwd)
        {
            DBHelper db = new DBHelper();

            List<Rider> list = new List<Rider>();

            Rider rider = null;

            string sql = "select RiderId, RiderNumber, RiderNumberPwd, RiderName, RiderPhone, RiderComment from Rider where RiderNumber=@RiderNumber and RiderNumberPwd=@RiderNumberPwd";

            SqlParameter[] sp =
            {
                new SqlParameter("@RiderNumber",uid),
                new SqlParameter("@RiderNumberPwd",pwd),
            };

            SqlDataReader sdr = db.ExecuteReader(sql, sp);
            if (sdr.Read())
            {
                rider = new Rider
                {
                    RiderId = (int)sdr["RiderId"],
                    RiderNumber = sdr["RiderNumber"].ToString(),
                    RiderNumberPwd = sdr["RiderNumberPwd"].ToString(),
                    RiderName = sdr["RiderName"].ToString(),
                    RiderPhone = sdr["RiderPhone"].ToString(),
                    RiderComment = sdr["RiderComment"].ToString(),

                };
                list.Add(rider);
            }
            return list;
        }

        /// <summary>
        /// 增加 和修改
        /// </summary>
        /// <param name="name">姓名</param>
        /// <param name="uid">账号</param>
        /// <param name="pwd">密码</param>
        /// <param name="phone">电话</param>
        /// <param name="id">判断是增加还是修改</param>
        /// <param name="riderId">用于修改哪一个骑手</param>
        /// <returns></returns>
        public List<Rider> AddAlter(string name,string uid,string pwd,string phone,int id=0,int riderId=0)
        {
            DBHelper db = new DBHelper();

            List<Rider> list = new List<Rider>();

            Rider rider = null;

            string sql=null;
            if (id == 0)
            {
                sql += "insert into Rider(RiderNumber, RiderNumberPwd, RiderName, RiderPhone) values(@RiderNumber,@RiderNumberPwd,@RiderName,@RiderPhone)";
            }
            else
            {
                sql += "update Rider set RiderNumber=@RiderNumber,RiderNumberPwd=@RiderNumberPwd,RiderName=@RiderName,RiderPhone=@RiderPhone where RiderId=@RiderId";
            }
           

            SqlParameter[] sp =
            {
                new SqlParameter("@RiderNumber",uid),
                new SqlParameter("@RiderNumberPwd",pwd),
                new SqlParameter("@RiderName",name),
                new SqlParameter("@RiderPhone",phone),
                new SqlParameter("@RiderId",riderId),
            };

            int count = db.ExecuteNonQuery(sql, sp);
            if (count > 0)
            {
                rider = new Rider
                {
                    RiderNumber = uid,
                    RiderNumberPwd = pwd,
                    RiderName = name,
                    RiderPhone =phone,
                };
                list.Add(rider);
            }
            return list;
        }
    }
}
