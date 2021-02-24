using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DianCanXiTongDAL;
using DianCanXiTongManager;

namespace DianCanXiTongBLL
{
    public class CuisineInformationsManager
    {
        private CuisinelnformationsService cS = new CuisinelnformationsService();
        /// <summary>
        /// 点餐查询，业务层
        /// </summary>
        /// <param name="leix"></param>
        public List<CuisineInformations> CuisinelnformationsSelectManager(string leix)
        {
            return cS.CuisinelnformationsSelectService(leix);
        }
    }
}
