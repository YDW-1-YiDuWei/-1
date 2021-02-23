using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DianCanXiTongManager
{
    public class Rider
    {

        public int RiderId { get; set; }//标识列ID
        public string RiderNumber { get; set; }//后面增加的骑手账号
        public string RiderNumberPwd { get; set; }//后面增加的骑手密码
        public string RiderName { get; set; }//骑手姓名
        public string RiderPhone { get; set; }//骑手电话
        public string RiderComment { get; set; }//骑手评价信息
    }
}
