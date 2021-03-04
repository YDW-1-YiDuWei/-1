using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DianCanXiTongBLL;
using DianCanXiTongManager;

namespace 点餐系统
{
    public partial class 骑手我的 : Form
    {
        public List<Rider> list = null;
        public 骑手我的()
        {

            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)//切换
        {
            骑手登入 qsdr = new 骑手登入();
            qsdr.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            骑手注册修改 qsdrxg = new 骑手注册修改();
            qsdrxg.Show();
        }

        private void 骑手我的_Load(object sender, EventArgs e)
        {
            button3.Enabled = true;
            if (list.Count == 1)
            {
                label2.Text = list[0].RiderName;
                label4.Text = list[0].RiderNumber;

            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否确认退出登录", "退出提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                button3.Enabled = false;
                label2.Text = "";
                label4.Text = "";
            }

        }
    }
}
