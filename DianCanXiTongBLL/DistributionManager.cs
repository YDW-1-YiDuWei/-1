using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DianCanXiTongDAL;

namespace DianCanXiTongBLL
{
    public class DistributionManager
    {
        /// <summary>
        /// 配送表，业务层
        /// </summary>
        /// <returns></returns>
        public int DistributionAddManager(string riderId, string cuisineId, string lientId, string restaurantId)
        {
            DistributionService distribution = new DistributionService();
            return distribution.CuisinelnformationsAddService(riderId, cuisineId, lientId, restaurantId);
        }
    }
}
