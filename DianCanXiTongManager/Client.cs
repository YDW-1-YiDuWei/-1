using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DianCanXiTongManager
{
    public class Client
    {
        public int Id { get; set; }//标识列ID
        public string Number { get; set; }//客户账号
        public string Name { get; set; }//客户姓名
        public char Sex { get; set; }//客户性别
        public string Phone { get; set; }//客户电话
        public string Password { get; set; }//客户密码
        public string Address { get; set; }//客户地址
    }
}
