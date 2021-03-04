using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DianCanXiTongDAL;
using DianCanXiTongManager;

namespace DianCanXiTongBLL
{
    /// <summary>
    /// 骑手业务层
    /// </summary>
    public class RiderManager
    {
        RiderService rider = new RiderService();

        public List<Rider> Longin(string uid, string pwd)
        {
            return rider.Longin(uid, pwd);
        }

        public List<Rider> AddAlter(string name, string uid, string pwd, string phone, int id = 0, int riderId = 0)
        {
            return rider.AddAlter(name, uid, pwd, phone, id, riderId);
        }
    }
}
