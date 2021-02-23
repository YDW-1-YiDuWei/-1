using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 点餐系统
{
    public partial class 首页 : Form
    {
        public 首页()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            餐馆列表 cglb = new 餐馆列表();
            cglb.Show();
            this.Close();

        }

        private void label4_Click(object sender, EventArgs e)
        {
            登录界面 dljm = new 登录界面();
            dljm.Show();
            this.Hide();

        }

        private void label5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("真的要退出程序吗？", "退出程序", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void label1_Click(object sender, EventArgs e)//我的
        {
            我的 wd = new 我的();
            wd.Show();
            this.Close();
        }

        private void Label2_Click(object sender, EventArgs e)//订单
        {
            订单 dd = new 订单();
            dd.Show();
            this.Hide();
        }
    }
}
