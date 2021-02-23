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
    public partial class 登录界面 : Form
    {
        public 登录界面()
        {
            InitializeComponent();
        }
        RestaurantManager restaurantManager = new RestaurantManager();
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtZH.Text.Trim() == "")
            {
                MessageBox.Show("请输入账号");
                txtZH.Focus();
                return;
            }
            if (txtPwd.Text.Trim() == "")
            {
                MessageBox.Show("请输入账号");
                txtPwd.Focus();
                return;
            }
            List<Restaurant> list = restaurantManager.Longin(txtZH.Text, txtPwd.Text);
            if (list.Count > 0)
            {
                首页 sy = new 首页();
                sy.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("账号或密码错误", "登录提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
    }
}
