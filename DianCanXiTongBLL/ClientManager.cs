using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DianCanXiTongDAL;
using DianCanXiTongManager;

namespace DianCanXiTongBLL
{
   
   public class ClientManager //客户业务类
    {
        ClientService clientservice = new ClientService();

        public List<Client> Login(string uid,string pwd)//用户登录
        {
            return clientservice.Login(uid, pwd);
        }
    }
}
