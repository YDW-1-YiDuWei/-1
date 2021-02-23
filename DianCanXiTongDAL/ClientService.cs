using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DianCanXiTongManager;

namespace DianCanXiTongDAL
{
    public class ClientService //用户数据层
    {
        public List<Client> Login(string uid, string pwd) //用户登录
        {
            SqlConnection coon = new SqlConnection("server=.;database=Order;uid=sa;pwd=sa");
            List<Client> list = new List<Client>();
            DBHelper db = new DBHelper();

            Client client = null;

            string sql = "select Number, Name,Phone ,Address from Client where Number=@Number and Password=@Password";

            SqlParameter[] sp =
            {
                new SqlParameter("@Number",uid),
                new SqlParameter("@Password",pwd),
            };
            coon.Open();

            SqlCommand cmd = new SqlCommand(sql, coon);
            cmd.Parameters.AddRange(sp);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                client = new Client
                {
                    Name = sdr["Name"].ToString(),
                    Number = sdr["Number"].ToString(),
                    Password = sdr["Phone"].ToString(),
                    Address = sdr["Address"].ToString()
                };
                list.Add(client);
            }
            return list;
        }
    }
}
