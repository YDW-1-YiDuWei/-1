using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DianCanXiTongManager;
using DianCanXiTongBLL;

namespace 点餐系统
{
    public partial class 餐馆列表 : Form
    {
        RestaurantManager restaurantManager = new RestaurantManager();
        public 餐馆列表()
        {
            InitializeComponent();
        }

        private void 餐馆列表_Load(object sender, EventArgs e)//显示窗体的时候
        {

        }

        private void button1_Click(object sender, EventArgs e)//查询按钮
        {
            lvSJXX.Clear();
            Inquire();
        }
        public void Inquire() //查询餐馆
        {
            DataTable dt = restaurantManager.InquireRestaurantName(txtSJ.Text.Trim());

            int i = 0;
            foreach (DataRow dr in dt.Rows)//循环表里的行
            {
                string gsName = dr[3].ToString();//餐馆名字
                string gsName2 = dr[4].ToString();//餐馆地址
                string gsName3 = dr[5].ToString();//餐馆电话
                if (i == 0)
                {
                    lvSJXX.Items.Add("餐馆名字：" + "    餐馆地址：" + "     餐馆电话：", i++);
                }
                lvSJXX.Items.Add("", i++);
                lvSJXX.Items.Add("", i++);
                lvSJXX.Items.Add(gsName + "       " + gsName2 + "        " + gsName3, i);//这里是关键!!!!!!!!!倒
                i++;
            }
        }
    }
}
