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
        public List<Client> list = new List<Client>();
        public List<Client> Login(string uid, string pwd) //用户登录
        {
            SqlConnection coon = new SqlConnection("server=.;database=Order;uid=sa;pwd=sa");

            list.Clear();

            Client client = null;

            string sql = "select Id,Number, Name,Phone,Password,Address from Client where Number=@Number and Password=@Password";

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
                    Id = (int)sdr["Id"],
                    Name = sdr["Name"].ToString(),
                    Number = sdr["Number"].ToString(),
                    Phone = sdr["Phone"].ToString(),
                    Password=sdr["Password"].ToString(),
                    Address = sdr["Address"].ToString()
                };
                list.Add(client);
            }
            return list;
        }
        public List<Client> Alter(string uid, string pwd, int id)//用户修改
        {
            SqlConnection coon = new SqlConnection("server=.;database=Order;uid=sa;pwd=sa");

            string sql = "update Client set Number=@Number,Password= @Password where Id =@Id";

            SqlParameter[] sp =
            {
                new SqlParameter("@Number",uid),
                new SqlParameter("@Password",pwd),
                new SqlParameter("@Id",id)

            };
            coon.Open();
            SqlCommand cmd = new SqlCommand(sql, coon);
            cmd.Parameters.AddRange(sp);
            int count = (int)cmd.ExecuteNonQuery();
            if (count > 0)
            {
                foreach (var item in list)
                {
                    item.Number = uid;
                    item.Password = pwd;
                }
            }
            else
            {
                list = null;
            }
            coon.Close();
            return list;
        }

    }
}
