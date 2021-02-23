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

        private void 餐馆列表_Load(object sender, EventArgs e)//查询窗体的时候
        {

        }

        private void button1_Click(object sender, EventArgs e)//查询按钮
        {
            DataTable dt=restaurantManager.InquireRestaurantName(txtSJ.Text);

            Image[] asg = new Image[2];
            int i = 0;
            foreach (DataRow dr in dt.Rows)
            {
                string gsName = dr[3].ToString();//歌手名字
                lvSJXX.Items.Add(gsName, i);//这里是关键!!!!!!!!!倒
                i++;
            }
        }
    }
}
