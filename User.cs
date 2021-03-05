using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 点餐系统
{
    public static class User
    {
       /// <summary>
        /// 用户账号密码记录
        /// </summary>
       public static string user = "";
       public static string pass="";
       public static string khID = "";


       /// <summary>
        /// 总价格
        /// </summary>
       public static string TotalPrices = "";
       /// <summary>
        /// 餐馆ID
        /// </summary>
       public static string RestaurantId = "";

       /// <summary>
       /// 商家账号密码记录
       /// </summary>
        public static string restaUser = "";
        public static string restaPass = "";
        public static string restaKhID = "";
        public static string path = "";


        /// <summary>
        /// 记录骑手的账号密码
        /// </summary>
        public static string riderKhId = "";
        public static string riderUser = "";
        public static string riderPwd = "";
        /// <summary>
        /// 骑手姓名
        /// </summary>
        public static string riderName = "";
    }
}
