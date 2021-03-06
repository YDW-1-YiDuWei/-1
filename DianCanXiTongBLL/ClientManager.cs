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
        
        public List<Client> Login(string uid,string pwd,string id="")//用户登录
        {
            return clientservice.Login(uid, pwd,id);
        }

        public List<Client> Alter(string uid,string pwd,int id)//用户修改
        {
            return clientservice.Alter(uid, pwd,id);
        }

        
        public List<Client> AddClients(string uid, string pwd)//用户注册
        {
            return clientservice.AddClients(uid,pwd);
        }

        public int CompileClientsMessage(string name, string sex, string phone, string address, string id)
        {
            return clientservice.CompileClientsMessage(name, sex, phone, address, id);
        }
    }
}
