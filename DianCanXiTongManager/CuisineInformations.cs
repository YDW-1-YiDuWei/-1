using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DianCanXiTongManager
{
    public class CuisineInformations
    {
        public int id { get; set; }//标识列ID
        public string CuisineName { get; set; }//菜品名称 
        public int RestaurantId { get; set; }//餐馆的标识列ID
        public int CuisineTypeId { get; set; }//菜品类型ID  
        public double CuisinePrice { get; set; }//菜品价格 
        public int CuisineCommentId { get; set; }//菜品评论ID 
        public int CuisineCount { get; set; }//菜品点餐次数 
        public string CuisineImagePath { get; set; }//菜品图片路径 
    }
}
