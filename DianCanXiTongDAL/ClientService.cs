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
        public List<Client> Login(string uid, string pwd,string id="") //用户登录
        {
            SqlConnection coon = new SqlConnection("server=.;database=Order;uid=sa;pwd=sa");

            list.Clear();

            Client client = null;

            string sql = "select Id,Number, Name,Phone,Password,Address from Client where Number=@Number and Password=@Password";

            if (id != "")
            {
                sql += " and Id=@Id";
            }
            SqlParameter[] sp =
            {
                new SqlParameter("@Number",uid),
                new SqlParameter("@Password",pwd),
                new SqlParameter("@Id",id),
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

        public List<Client> AddClients(string uid,string pwd)//用户账号注册
        {
            SqlConnection coon = new SqlConnection("server=.;database=Order;uid=sa;pwd=sa");

            list.Clear();

            Client client = null;

            string sql = "insert into Client(Name,Number,Password) values(@Name,@Number,@Password)";

            coon.Open();

            SqlParameter[] sp =
            {
                new SqlParameter("@Name",uid),
                new SqlParameter("@Number",uid),
                new SqlParameter("@Password",pwd)
            };
            SqlCommand cmd = new SqlCommand(sql, coon);
            cmd.Parameters.AddRange(sp);
            int count = cmd.ExecuteNonQuery();
            if (count > 0)
            {
                client = new Client
                {
                    Name=uid,
                    Number=uid,
                    Password=pwd,
                };
                list.Add(client);
            }
            return list;
        }
        public int CompileClientsMessage(string name,string sex,string phone,string address,string id)//编辑用户信息1
        {
            DBHelper db = new DBHelper();

            string sql = "update Client set  Name=@Name, Sex=@Sex,Phone=@Phone, Address=@Address where Id=@Id";

            SqlParameter[] sp =
            {
                new SqlParameter("@Name",name),
                new SqlParameter("@Sex",sex),
                new SqlParameter("@Phone",phone),
                new SqlParameter("@Address",address),
                new SqlParameter("@Id",id),
            };
            int count = db.ExecuteNonQuery(sql, sp);
            if (count > 0)
            {
                return count;
            }
            return count;
        }

    }
}
